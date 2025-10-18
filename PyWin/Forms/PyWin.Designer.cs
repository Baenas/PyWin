namespace PyWin.Forms
{
    partial class PyWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            txt_user = new Label();
            button1 = new Button();
            ServerConsole = new ListBox();
            btnGo = new Button();
            txtCommand = new TextBox();
            check_folder = new CheckBox();
            check_file = new CheckBox();
            combo_categorias = new ComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SandyBrown;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txt_user);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1486, 42);
            panel1.TabIndex = 4;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // txt_user
            // 
            txt_user.AutoSize = true;
            txt_user.Location = new Point(8, 9);
            txt_user.Name = "txt_user";
            txt_user.Size = new Size(0, 25);
            txt_user.TabIndex = 8;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Right;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(1434, 0);
            button1.Name = "button1";
            button1.Size = new Size(50, 40);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ServerConsole
            // 
            ServerConsole.FormattingEnabled = true;
            ServerConsole.ItemHeight = 25;
            ServerConsole.Location = new Point(12, 143);
            ServerConsole.Name = "ServerConsole";
            ServerConsole.Size = new Size(704, 729);
            ServerConsole.TabIndex = 7;
            // 
            // btnGo
            // 
            btnGo.Location = new Point(604, 94);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(112, 34);
            btnGo.TabIndex = 6;
            btnGo.Text = "GO";
            btnGo.UseVisualStyleBackColor = true;
            // 
            // txtCommand
            // 
            txtCommand.Location = new Point(12, 95);
            txtCommand.Name = "txtCommand";
            txtCommand.Size = new Size(586, 31);
            txtCommand.TabIndex = 5;
            // 
            // check_folder
            // 
            check_folder.AutoSize = true;
            check_folder.Location = new Point(732, 143);
            check_folder.Name = "check_folder";
            check_folder.Size = new Size(96, 29);
            check_folder.TabIndex = 8;
            check_folder.Text = "Folders";
            check_folder.UseVisualStyleBackColor = true;
            // 
            // check_file
            // 
            check_file.AutoSize = true;
            check_file.Location = new Point(732, 178);
            check_file.Name = "check_file";
            check_file.Size = new Size(72, 29);
            check_file.TabIndex = 9;
            check_file.Text = "Files";
            check_file.UseVisualStyleBackColor = true;
            // 
            // combo_categorias
            // 
            combo_categorias.FormattingEnabled = true;
            combo_categorias.Location = new Point(1273, 143);
            combo_categorias.Name = "combo_categorias";
            combo_categorias.Size = new Size(182, 33);
            combo_categorias.TabIndex = 10;
            // 
            // PyWin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(1486, 889);
            Controls.Add(combo_categorias);
            Controls.Add(check_file);
            Controls.Add(check_folder);
            Controls.Add(ServerConsole);
            Controls.Add(btnGo);
            Controls.Add(txtCommand);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PyWin";
            Text = "PyWin";
            Load += PyWin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private ListBox ServerConsole;
        private Button btnGo;
        private TextBox txtCommand;
        private Label txt_user;
        private CheckBox check_folder;
        private CheckBox check_file;
        private ComboBox combo_categorias;
    }
}