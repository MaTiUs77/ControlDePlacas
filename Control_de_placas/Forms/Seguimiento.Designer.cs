namespace Control_de_placas
{
    partial class Seguimiento
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.inRestantes = new System.Windows.Forms.TextBox();
            this.inTitulo = new System.Windows.Forms.GroupBox();
            this.comboPanel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inTotal = new System.Windows.Forms.TextBox();
            this.inSalidas = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.inTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(16, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Lote por:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(23, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Salidas:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(5, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Restantes:";
            // 
            // inRestantes
            // 
            this.inRestantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.inRestantes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inRestantes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.inRestantes.Location = new System.Drawing.Point(84, 98);
            this.inRestantes.Name = "inRestantes";
            this.inRestantes.ReadOnly = true;
            this.inRestantes.Size = new System.Drawing.Size(90, 23);
            this.inRestantes.TabIndex = 4;
            this.inRestantes.Text = "0";
            this.inRestantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // inTitulo
            // 
            this.inTitulo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.inTitulo.Controls.Add(this.button1);
            this.inTitulo.Controls.Add(this.comboPanel);
            this.inTitulo.Controls.Add(this.label1);
            this.inTitulo.Controls.Add(this.label3);
            this.inTitulo.Controls.Add(this.inTotal);
            this.inTitulo.Controls.Add(this.label5);
            this.inTitulo.Controls.Add(this.label4);
            this.inTitulo.Controls.Add(this.inSalidas);
            this.inTitulo.Controls.Add(this.inRestantes);
            this.inTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inTitulo.ForeColor = System.Drawing.Color.Blue;
            this.inTitulo.Location = new System.Drawing.Point(3, 3);
            this.inTitulo.Name = "inTitulo";
            this.inTitulo.Size = new System.Drawing.Size(189, 158);
            this.inTitulo.TabIndex = 5;
            this.inTitulo.TabStop = false;
            this.inTitulo.Text = "Modelo";
            // 
            // comboPanel
            // 
            this.comboPanel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPanel.FormattingEnabled = true;
            this.comboPanel.Location = new System.Drawing.Point(84, 24);
            this.comboPanel.Name = "comboPanel";
            this.comboPanel.Size = new System.Drawing.Size(90, 24);
            this.comboPanel.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(33, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Panel:";
            // 
            // inTotal
            // 
            this.inTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.inTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inTotal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.inTotal.Location = new System.Drawing.Point(84, 53);
            this.inTotal.Name = "inTotal";
            this.inTotal.ReadOnly = true;
            this.inTotal.Size = new System.Drawing.Size(90, 20);
            this.inTotal.TabIndex = 6;
            this.inTotal.Text = "0";
            this.inTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // inSalidas
            // 
            this.inSalidas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.inSalidas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inSalidas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.inSalidas.Location = new System.Drawing.Point(84, 74);
            this.inSalidas.Name = "inSalidas";
            this.inSalidas.ReadOnly = true;
            this.inSalidas.Size = new System.Drawing.Size(90, 23);
            this.inSalidas.TabIndex = 5;
            this.inSalidas.Text = "0";
            this.inSalidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(8, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Refrescar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Seguimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 164);
            this.Controls.Add(this.inTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Seguimiento";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Seguimiento";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Seguimiento_Load);
            this.inTitulo.ResumeLayout(false);
            this.inTitulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inRestantes;
        private System.Windows.Forms.GroupBox inTitulo;
        private System.Windows.Forms.TextBox inTotal;
        private System.Windows.Forms.TextBox inSalidas;
        private System.Windows.Forms.ComboBox comboPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;


    }
}