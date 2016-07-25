namespace Control_de_placas
{
    partial class formUsuario
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridUsuario = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.inNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inClave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.inTurno = new System.Windows.Forms.ComboBox();
            this.btAgregar = new System.Windows.Forms.Button();
            this.xid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xnombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xturno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xed = new System.Windows.Forms.DataGridViewButtonColumn();
            this.xel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuario)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btAgregar);
            this.groupBox1.Controls.Add(this.inTurno);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.inClave);
            this.groupBox1.Controls.Add(this.inNombre);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion de usuario";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridUsuario);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(218, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 196);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usuarios creados";
            // 
            // gridUsuario
            // 
            this.gridUsuario.AllowUserToAddRows = false;
            this.gridUsuario.AllowUserToDeleteRows = false;
            this.gridUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xid,
            this.xnombre,
            this.xturno,
            this.xed,
            this.xel});
            this.gridUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUsuario.Location = new System.Drawing.Point(3, 16);
            this.gridUsuario.Name = "gridUsuario";
            this.gridUsuario.ReadOnly = true;
            this.gridUsuario.RowHeadersVisible = false;
            this.gridUsuario.Size = new System.Drawing.Size(363, 177);
            this.gridUsuario.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.45485F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.54515F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(590, 202);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // inNombre
            // 
            this.inNombre.Location = new System.Drawing.Point(22, 39);
            this.inNombre.Name = "inNombre";
            this.inNombre.Size = new System.Drawing.Size(170, 20);
            this.inNombre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre ";
            // 
            // inClave
            // 
            this.inClave.Location = new System.Drawing.Point(22, 81);
            this.inClave.Name = "inClave";
            this.inClave.Size = new System.Drawing.Size(170, 20);
            this.inClave.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Clave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Turno";
            // 
            // inTurno
            // 
            this.inTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inTurno.FormattingEnabled = true;
            this.inTurno.Location = new System.Drawing.Point(22, 125);
            this.inTurno.Name = "inTurno";
            this.inTurno.Size = new System.Drawing.Size(170, 21);
            this.inTurno.TabIndex = 2;
            // 
            // btAgregar
            // 
            this.btAgregar.Location = new System.Drawing.Point(22, 152);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(170, 32);
            this.btAgregar.TabIndex = 3;
            this.btAgregar.Text = "Agregar";
            this.btAgregar.UseVisualStyleBackColor = true;
            this.btAgregar.Click += new System.EventHandler(this.btAgregar_Click);
            // 
            // xid
            // 
            this.xid.HeaderText = "id";
            this.xid.Name = "xid";
            this.xid.ReadOnly = true;
            this.xid.Visible = false;
            // 
            // xnombre
            // 
            this.xnombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.xnombre.HeaderText = "Nombre";
            this.xnombre.Name = "xnombre";
            this.xnombre.ReadOnly = true;
            // 
            // xturno
            // 
            this.xturno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.xturno.HeaderText = "Turno";
            this.xturno.Name = "xturno";
            this.xturno.ReadOnly = true;
            this.xturno.Width = 60;
            // 
            // xed
            // 
            this.xed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.xed.HeaderText = "";
            this.xed.Name = "xed";
            this.xed.ReadOnly = true;
            this.xed.Width = 5;
            // 
            // xel
            // 
            this.xel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.xel.HeaderText = "";
            this.xel.Name = "xel";
            this.xel.ReadOnly = true;
            this.xel.Width = 5;
            // 
            // formUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 202);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "formUsuario";
            this.Text = "Administracion de usuarios";
            this.Load += new System.EventHandler(this.formUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuario)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btAgregar;
        private System.Windows.Forms.ComboBox inTurno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inClave;
        private System.Windows.Forms.TextBox inNombre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridUsuario;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn xid;
        private System.Windows.Forms.DataGridViewTextBoxColumn xnombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn xturno;
        private System.Windows.Forms.DataGridViewButtonColumn xed;
        private System.Windows.Forms.DataGridViewButtonColumn xel;
    }
}