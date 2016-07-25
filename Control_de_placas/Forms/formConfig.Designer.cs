namespace Control_de_placas
{
    partial class formConfig
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarConfiguracioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.inClave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inDatabase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inServer = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.inListas = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(442, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cargarToolStripMenuItem
            // 
            this.cargarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarConfiguracioToolStripMenuItem});
            this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
            this.cargarToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.cargarToolStripMenuItem.Text = "Opciones";
            // 
            // guardarConfiguracioToolStripMenuItem
            // 
            this.guardarConfiguracioToolStripMenuItem.Name = "guardarConfiguracioToolStripMenuItem";
            this.guardarConfiguracioToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.guardarConfiguracioToolStripMenuItem.Text = "Guardar";
            this.guardarConfiguracioToolStripMenuItem.Click += new System.EventHandler(this.guardarConfiguracioToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.inClave);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.inDatabase);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.inUsuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.inServer);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 198);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MySQL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Clave";
            // 
            // inClave
            // 
            this.inClave.BackColor = System.Drawing.SystemColors.Info;
            this.inClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inClave.Location = new System.Drawing.Point(15, 153);
            this.inClave.Name = "inClave";
            this.inClave.PasswordChar = '*';
            this.inClave.Size = new System.Drawing.Size(174, 20);
            this.inClave.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Database";
            // 
            // inDatabase
            // 
            this.inDatabase.BackColor = System.Drawing.SystemColors.Info;
            this.inDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inDatabase.Location = new System.Drawing.Point(15, 75);
            this.inDatabase.Name = "inDatabase";
            this.inDatabase.Size = new System.Drawing.Size(174, 20);
            this.inDatabase.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Usuario";
            // 
            // inUsuario
            // 
            this.inUsuario.BackColor = System.Drawing.SystemColors.Info;
            this.inUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inUsuario.Location = new System.Drawing.Point(15, 114);
            this.inUsuario.Name = "inUsuario";
            this.inUsuario.Size = new System.Drawing.Size(174, 20);
            this.inUsuario.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Server";
            // 
            // inServer
            // 
            this.inServer.BackColor = System.Drawing.SystemColors.Info;
            this.inServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inServer.Location = new System.Drawing.Point(15, 36);
            this.inServer.Name = "inServer";
            this.inServer.Size = new System.Drawing.Size(174, 20);
            this.inServer.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.inListas);
            this.groupBox2.Location = new System.Drawing.Point(225, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 198);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rutas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Carpeta LISTAS";
            // 
            // inListas
            // 
            this.inListas.BackColor = System.Drawing.SystemColors.Info;
            this.inListas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inListas.Location = new System.Drawing.Point(15, 36);
            this.inListas.Name = "inListas";
            this.inListas.Size = new System.Drawing.Size(174, 20);
            this.inListas.TabIndex = 4;
            // 
            // formConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 232);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formConfig";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion de Servidor";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formConfig_FormClosed);
            this.Load += new System.EventHandler(this.formConfig_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarConfiguracioToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inServer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inListas;
    }
}