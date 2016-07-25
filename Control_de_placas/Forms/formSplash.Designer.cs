namespace Control_de_placas
{
    partial class formSplash
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
            this.inClave = new System.Windows.Forms.TextBox();
            this.btn_acceder = new System.Windows.Forms.Button();
            this.box_login = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboConfig = new System.Windows.Forms.ComboBox();
            this.panel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.comboDestino = new System.Windows.Forms.ComboBox();
            this.btn_server = new System.Windows.Forms.Button();
            this.box_login.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inClave
            // 
            this.inClave.BackColor = System.Drawing.SystemColors.Info;
            this.inClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inClave.Location = new System.Drawing.Point(48, 70);
            this.inClave.Name = "inClave";
            this.inClave.PasswordChar = '*';
            this.inClave.Size = new System.Drawing.Size(179, 20);
            this.inClave.TabIndex = 0;
            this.inClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inClave_KeyPress);
            // 
            // btn_acceder
            // 
            this.btn_acceder.Location = new System.Drawing.Point(48, 96);
            this.btn_acceder.Name = "btn_acceder";
            this.btn_acceder.Size = new System.Drawing.Size(180, 23);
            this.btn_acceder.TabIndex = 2;
            this.btn_acceder.Text = "Acceder";
            this.btn_acceder.UseVisualStyleBackColor = true;
            this.btn_acceder.Click += new System.EventHandler(this.button1_Click);
            // 
            // box_login
            // 
            this.box_login.Controls.Add(this.panel1);
            this.box_login.Controls.Add(this.label3);
            this.box_login.Controls.Add(this.label2);
            this.box_login.Controls.Add(this.label1);
            this.box_login.Controls.Add(this.inClave);
            this.box_login.Controls.Add(this.btn_acceder);
            this.box_login.Location = new System.Drawing.Point(4, 0);
            this.box_login.Name = "box_login";
            this.box_login.Size = new System.Drawing.Size(271, 157);
            this.box_login.TabIndex = 3;
            this.box_login.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(57, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "(si no dispone ingrese: invitado) ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ingresar clave de acceso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Control de Placas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboConfig);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(131, 50);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Servidor";
            // 
            // comboConfig
            // 
            this.comboConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboConfig.FormattingEnabled = true;
            this.comboConfig.Location = new System.Drawing.Point(6, 18);
            this.comboConfig.Name = "comboConfig";
            this.comboConfig.Size = new System.Drawing.Size(116, 21);
            this.comboConfig.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.ColumnCount = 2;
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.panel.Controls.Add(this.groupBox2, 0, 0);
            this.panel.Location = new System.Drawing.Point(135, 211);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(5);
            this.panel.RowCount = 1;
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel.Size = new System.Drawing.Size(447, 197);
            this.panel.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboDestino);
            this.panel1.Controls.Add(this.btn_server);
            this.panel1.Location = new System.Drawing.Point(6, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 106);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Seleccione un servidor de operaciones";
            // 
            // comboDestino
            // 
            this.comboDestino.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDestino.FormattingEnabled = true;
            this.comboDestino.Location = new System.Drawing.Point(34, 38);
            this.comboDestino.Name = "comboDestino";
            this.comboDestino.Size = new System.Drawing.Size(188, 24);
            this.comboDestino.TabIndex = 8;
            // 
            // btn_server
            // 
            this.btn_server.Location = new System.Drawing.Point(85, 68);
            this.btn_server.Name = "btn_server";
            this.btn_server.Size = new System.Drawing.Size(75, 26);
            this.btn_server.TabIndex = 7;
            this.btn_server.Text = "Aceptar";
            this.btn_server.UseVisualStyleBackColor = true;
            this.btn_server.Click += new System.EventHandler(this.btn_server_Click);
            // 
            // formSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 160);
            this.Controls.Add(this.box_login);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autentificacion";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formSplash_FormClosing);
            this.Load += new System.EventHandler(this.formSplash_Load);
            this.box_login.ResumeLayout(false);
            this.box_login.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox inClave;
        private System.Windows.Forms.Button btn_acceder;
        private System.Windows.Forms.GroupBox box_login;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboConfig;
        private System.Windows.Forms.TableLayoutPanel panel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboDestino;
        private System.Windows.Forms.Button btn_server;
    }
}