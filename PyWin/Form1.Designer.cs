namespace PyWin
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtCommand = new TextBox();
            btnGo = new Button();
            ServerConsole = new ListBox();
            panel1 = new Panel();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtCommand
            // 
            txtCommand.Location = new Point(12, 73);
            txtCommand.Name = "txtCommand";
            txtCommand.Size = new Size(586, 31);
            txtCommand.TabIndex = 0;
            // 
            // btnGo
            // 
            btnGo.Location = new Point(604, 73);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(112, 34);
            btnGo.TabIndex = 1;
            btnGo.Text = "GO";
            btnGo.UseVisualStyleBackColor = true;
            // 
            // ServerConsole
            // 
            ServerConsole.FormattingEnabled = true;
            ServerConsole.ItemHeight = 25;
            ServerConsole.Location = new Point(12, 136);
            ServerConsole.Name = "ServerConsole";
            ServerConsole.Size = new Size(704, 704);
            ServerConsole.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = Color.RosyBrown;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1462, 42);
            panel1.TabIndex = 3;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Right;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.icons8_close_40;
            button1.Location = new Point(1410, 0);
            button1.Name = "button1";
            button1.Size = new Size(50, 40);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1462, 852);
            Controls.Add(panel1);
            Controls.Add(ServerConsole);
            Controls.Add(btnGo);
            Controls.Add(txtCommand);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCommand;
        private Button btnGo;
        private ListBox ServerConsole;
        private Panel panel1;
        private Button button1;
    }
}
