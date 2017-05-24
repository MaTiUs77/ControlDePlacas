namespace Control_de_placas
{
    partial class formFiltro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formFiltro));
            this.comboPlaca = new System.Windows.Forms.ComboBox();
            this.comboLote = new System.Windows.Forms.ComboBox();
            this.comboModelo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FechaDesde = new System.Windows.Forms.DateTimePicker();
            this.btGuardar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboDestino = new System.Windows.Forms.ComboBox();
            this.lblDestino = new System.Windows.Forms.Label();
            this.comboRecepcion = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.comboEbs = new System.Windows.Forms.ComboBox();
            this.labelEbs = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboPlaca
            // 
            this.comboPlaca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comboPlaca.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPlaca.FormattingEnabled = true;
            this.comboPlaca.Location = new System.Drawing.Point(29, 121);
            this.comboPlaca.Name = "comboPlaca";
            this.comboPlaca.Size = new System.Drawing.Size(121, 24);
            this.comboPlaca.TabIndex = 2;
            // 
            // comboLote
            // 
            this.comboLote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comboLote.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLote.FormattingEnabled = true;
            this.comboLote.Location = new System.Drawing.Point(29, 78);
            this.comboLote.Name = "comboLote";
            this.comboLote.Size = new System.Drawing.Size(121, 24);
            this.comboLote.TabIndex = 1;
            // 
            // comboModelo
            // 
            this.comboModelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comboModelo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboModelo.FormattingEnabled = true;
            this.comboModelo.Location = new System.Drawing.Point(29, 35);
            this.comboModelo.Name = "comboModelo";
            this.comboModelo.Size = new System.Drawing.Size(121, 24);
            this.comboModelo.TabIndex = 0;
            this.comboModelo.SelectedIndexChanged += new System.EventHandler(this.comboModelo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Placa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Lote";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Modelo";
            // 
            // FechaHasta
            // 
            this.FechaHasta.CustomFormat = "dd/MM/yyyy";
            this.FechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaHasta.Location = new System.Drawing.Point(181, 203);
            this.FechaHasta.Name = "FechaHasta";
            this.FechaHasta.Size = new System.Drawing.Size(121, 24);
            this.FechaHasta.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(178, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Hasta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Desde";
            // 
            // FechaDesde
            // 
            this.FechaDesde.CustomFormat = "dd/MM/yyyy";
            this.FechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaDesde.Location = new System.Drawing.Point(29, 203);
            this.FechaDesde.Name = "FechaDesde";
            this.FechaDesde.Size = new System.Drawing.Size(121, 24);
            this.FechaDesde.TabIndex = 3;
            // 
            // btGuardar
            // 
            this.btGuardar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btGuardar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardar.Location = new System.Drawing.Point(29, 243);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(121, 30);
            this.btGuardar.TabIndex = 7;
            this.btGuardar.Text = "Filtrar";
            this.btGuardar.UseVisualStyleBackColor = false;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(181, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // comboDestino
            // 
            this.comboDestino.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comboDestino.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDestino.FormattingEnabled = true;
            this.comboDestino.Location = new System.Drawing.Point(181, 35);
            this.comboDestino.Name = "comboDestino";
            this.comboDestino.Size = new System.Drawing.Size(121, 24);
            this.comboDestino.TabIndex = 5;
            this.comboDestino.SelectedIndexChanged += new System.EventHandler(this.comboModelo_SelectedIndexChanged);
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestino.Location = new System.Drawing.Point(178, 19);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(43, 13);
            this.lblDestino.TabIndex = 9;
            this.lblDestino.Text = "Destino";
            // 
            // comboRecepcion
            // 
            this.comboRecepcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comboRecepcion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboRecepcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRecepcion.FormattingEnabled = true;
            this.comboRecepcion.Location = new System.Drawing.Point(181, 78);
            this.comboRecepcion.Name = "comboRecepcion";
            this.comboRecepcion.Size = new System.Drawing.Size(121, 24);
            this.comboRecepcion.TabIndex = 6;
            this.comboRecepcion.SelectedIndexChanged += new System.EventHandler(this.comboModelo_SelectedIndexChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(178, 62);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 9;
            this.lblEstado.Text = "Estado";
            // 
            // comboEbs
            // 
            this.comboEbs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comboEbs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboEbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEbs.FormattingEnabled = true;
            this.comboEbs.Location = new System.Drawing.Point(181, 121);
            this.comboEbs.Name = "comboEbs";
            this.comboEbs.Size = new System.Drawing.Size(121, 24);
            this.comboEbs.TabIndex = 6;
            this.comboEbs.SelectedIndexChanged += new System.EventHandler(this.comboModelo_SelectedIndexChanged);
            // 
            // labelEbs
            // 
            this.labelEbs.AutoSize = true;
            this.labelEbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEbs.Location = new System.Drawing.Point(178, 105);
            this.labelEbs.Name = "labelEbs";
            this.labelEbs.Size = new System.Drawing.Size(28, 13);
            this.labelEbs.TabIndex = 9;
            this.labelEbs.Text = "EBS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "OP";
            // 
            // txtOp
            // 
            this.txtOp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtOp.Location = new System.Drawing.Point(29, 164);
            this.txtOp.Name = "txtOp";
            this.txtOp.Size = new System.Drawing.Size(121, 20);
            this.txtOp.TabIndex = 18;
            // 
            // formFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 291);
            this.Controls.Add(this.txtOp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FechaDesde);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FechaHasta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelEbs);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboPlaca);
            this.Controls.Add(this.comboLote);
            this.Controls.Add(this.comboEbs);
            this.Controls.Add(this.comboRecepcion);
            this.Controls.Add(this.comboDestino);
            this.Controls.Add(this.comboModelo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formFiltro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtro";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.formFiltro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboPlaca;
        private System.Windows.Forms.ComboBox comboLote;
        private System.Windows.Forms.ComboBox comboModelo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FechaHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker FechaDesde;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboDestino;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.ComboBox comboRecepcion;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox comboEbs;
        private System.Windows.Forms.Label labelEbs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOp;
    }
}