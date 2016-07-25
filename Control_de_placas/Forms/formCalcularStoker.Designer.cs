namespace Control_de_placas
{
    partial class formCalcularStoker
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
            this.button1 = new System.Windows.Forms.Button();
            this.inStokers = new System.Windows.Forms.TextBox();
            this.inCstokers = new System.Windows.Forms.TextBox();
            this.inBloques = new System.Windows.Forms.TextBox();
            this.inInc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inStokers
            // 
            this.inStokers.Location = new System.Drawing.Point(40, 37);
            this.inStokers.Name = "inStokers";
            this.inStokers.Size = new System.Drawing.Size(144, 20);
            this.inStokers.TabIndex = 0;
            // 
            // inCstokers
            // 
            this.inCstokers.Location = new System.Drawing.Point(40, 78);
            this.inCstokers.Name = "inCstokers";
            this.inCstokers.Size = new System.Drawing.Size(144, 20);
            this.inCstokers.TabIndex = 1;
            // 
            // inBloques
            // 
            this.inBloques.Location = new System.Drawing.Point(40, 119);
            this.inBloques.Name = "inBloques";
            this.inBloques.Size = new System.Drawing.Size(144, 20);
            this.inBloques.TabIndex = 2;
            // 
            // inInc
            // 
            this.inInc.Location = new System.Drawing.Point(40, 162);
            this.inInc.Name = "inInc";
            this.inInc.Size = new System.Drawing.Size(144, 20);
            this.inInc.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cantidad de Stokers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Paneles por Stoker";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bloques por panel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Incompletos / Sobrecargados";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inStokers);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.inCstokers);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.inBloques);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.inInc);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 223);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // formCalcularStoker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 223);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formCalcularStoker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calcular Stoker";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formCalcularStoker_FormClosed);
            this.Load += new System.EventHandler(this.formCalcularStoker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox inStokers;
        private System.Windows.Forms.TextBox inCstokers;
        private System.Windows.Forms.TextBox inBloques;
        private System.Windows.Forms.TextBox inInc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}