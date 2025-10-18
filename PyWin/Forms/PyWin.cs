using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace PyWin.Forms
{
    public partial class PyWin : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public static string appFolder = Path.Combine(
              Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
              "PyWin"


          );

        public static string dbPath = Path.Combine(appFolder, "database.sqlite");

        public static readonly string ConnectionString =
          $"Data Source={dbPath};Version=3;";


        Regex regex = new Regex(@"\b([\w\.-]+)\.([a-zA-Z0-9]+)\b");

        public PyWin()
        {
            InitializeComponent();
            InicializarBaseDeDatos();
            CargarUsuarios();
            CargarUsuariosEnCombo();
            Run();
        }
        private void Run()
        {
            Task.Factory.StartNew(() =>
            {

                Process ps = new Process();
                ps.StartInfo = new ProcessStartInfo("cmd.exe")
                {
                    WorkingDirectory = @"C:\",
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };
                this.btnGo.Click += (s, e) => Go(ps);

                ps.ErrorDataReceived += (s, e) => Log(e.Data);
                ps.OutputDataReceived += (s, e) => Log(e.Data);
                ps.Start();
                ps.BeginErrorReadLine();
                ps.BeginOutputReadLine();
                ps.WaitForExit();
            });
        }
        private void InicializarBaseDeDatos()
        {
            if (!Directory.Exists(appFolder))
                Directory.CreateDirectory(appFolder);

            dbPath = Path.Combine(appFolder, "database.sqlite");

            if (!File.Exists(dbPath))
            {
                CrearBaseDeDatos();
            }
            else
            {
                Console.WriteLine("✅ Base de datos ya existente en: " + dbPath);
            }
        }

        private void CrearBaseDeDatos()
        {
            try
            {
                SQLiteConnection.CreateFile(dbPath);

                using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    conn.Open();

                    string sql = @"
                        CREATE TABLE IF NOT EXISTS usuarios (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            nombre TEXT NOT NULL,
                            tipo TEXT NOT NULL
                            
                        );

                         CREATE TABLE IF NOT EXISTS comandos (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            nombre TEXT NOT NULL,
                            comando TEXT NOT NULL,
                            categoria TEXT
                        );
                    ";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    string insertSql = @"
                INSERT INTO usuarios (nombre, tipo)
                VALUES (@nombre, @tipo);
            ";

                    using (var insertCmd = new SQLiteCommand(insertSql, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@nombre", "Administrador");
                        insertCmd.Parameters.AddWithValue("@tipo", "admin");
                        insertCmd.ExecuteNonQuery();
                    }


                    MessageBox.Show(
                        "Base de datos creada correctamente en:\n" + dbPath,
                        "Inicialización completada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al crear la base de datos:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void Log(string value)


        {
            if (ServerConsole.IsDisposed)
            {
                return;
            }

            if (ServerConsole.InvokeRequired)
            {
                ServerConsole.Invoke(new Action(() =>
                {
                    if (txtCommand.Text == "dir")
                    {
                        if (value.Contains("<DIR>") && check_folder.Checked)
                        {
                            ServerConsole.Items.Add(value);
                        }

                        else if (!value.Contains("<DIR>") && check_file.Checked)
                        {
                            ServerConsole.Items.Add(value);
                        }
                        else if (!check_file.Checked &&  !check_folder.Checked )
                        {
                            ServerConsole.Items.Add(value);
                        }

                    }
                    else
                    {
                        ServerConsole.Items.Add(value);

                    }

                }));
            }
            else
                
            {
                ServerConsole.Items.Add(value);
            }
        }

        private void Go(Process ps)
        {
            ServerConsole.Items.Clear();
            ps.StandardInput.WriteLine(this.txtCommand.Text);

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarUsuarios()
        {
            try
            {
                string sql = "SELECT id, nombre, tipo FROM usuarios";

                using (var conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();

                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader.GetString(1);
                            txt_user.Text = nombre;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer usuarios:\n" + ex.Message);
            }
        }

        private void PyWin_Load(object sender, EventArgs e)
        {

        }

        private void CargarUsuariosEnCombo()
        {
            try
            {
                using (var conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();

                    string sql = "SELECT id, categoria FROM comandos ORDER BY id";

                    using (var da = new SQLiteDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        combo_categorias.DataSource = dt;
                        combo_categorias.DisplayMember = "nombre"; // lo que ve el usuario
                        combo_categorias.ValueMember = "id";       // el valor interno
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios:\n" + ex.Message);
            }
        }
    }
}
