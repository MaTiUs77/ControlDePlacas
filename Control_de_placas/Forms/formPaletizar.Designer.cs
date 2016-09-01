namespace Control_de_placas
{
    partial class formPaletizar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.dataPalet = new System.Windows.Forms.DataGridView();
            this._barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._declarado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailPalet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboDestino = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDescontar = new System.Windows.Forms.Button();
            this.removeMode = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.errorText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataPalet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(10, 39);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(198, 26);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stocker barcode:";
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnFinish.Enabled = false;
            this.btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(237, 310);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(197, 40);
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "Confirmar carga";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // dataPalet
            // 
            this.dataPalet.AllowUserToAddRows = false;
            this.dataPalet.AllowUserToDeleteRows = false;
            this.dataPalet.AllowUserToResizeColumns = false;
            this.dataPalet.AllowUserToResizeRows = false;
            this.dataPalet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPalet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._barcode,
            this._cantidad,
            this._declarado});
            this.dataPalet.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataPalet.Location = new System.Drawing.Point(6, 39);
            this.dataPalet.MultiSelect = false;
            this.dataPalet.Name = "dataPalet";
            this.dataPalet.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataPalet.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataPalet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataPalet.ShowEditingIcon = false;
            this.dataPalet.Size = new System.Drawing.Size(453, 311);
            this.dataPalet.TabIndex = 4;
            // 
            // _barcode
            // 
            this._barcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._barcode.HeaderText = "Barcode";
            this._barcode.Name = "_barcode";
            this._barcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._barcode.Width = 53;
            // 
            // _cantidad
            // 
            this._cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._cantidad.HeaderText = "Cantidad";
            this._cantidad.Name = "_cantidad";
            this._cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._cantidad.Width = 55;
            // 
            // _declarado
            // 
            this._declarado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._declarado.HeaderText = "Declarado";
            this._declarado.Name = "_declarado";
            this._declarado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // detailPalet
            // 
            this.detailPalet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.detailPalet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailPalet.Location = new System.Drawing.Point(10, 71);
            this.detailPalet.Multiline = true;
            this.detailPalet.Name = "detailPalet";
            this.detailPalet.ReadOnly = true;
            this.detailPalet.Size = new System.Drawing.Size(424, 138);
            this.detailPalet.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(233, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Destino:";
            // 
            // comboDestino
            // 
            this.comboDestino.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDestino.DropDownWidth = 200;
            this.comboDestino.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDestino.FormattingEnabled = true;
            this.comboDestino.Location = new System.Drawing.Point(237, 39);
            this.comboDestino.Name = "comboDestino";
            this.comboDestino.Size = new System.Drawing.Size(197, 24);
            this.comboDestino.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Palet";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.errorText);
            this.groupBox1.Controls.Add(this.btnDescontar);
            this.groupBox1.Controls.Add(this.removeMode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBarcode);
            this.groupBox1.Controls.Add(this.comboDestino);
            this.groupBox1.Controls.Add(this.btnFinish);
            this.groupBox1.Controls.Add(this.detailPalet);
            this.groupBox1.Location = new System.Drawing.Point(479, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 360);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // btnDescontar
            // 
            this.btnDescontar.BackColor = System.Drawing.Color.Tomato;
            this.btnDescontar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescontar.Location = new System.Drawing.Point(10, 310);
            this.btnDescontar.Name = "btnDescontar";
            this.btnDescontar.Size = new System.Drawing.Size(198, 40);
            this.btnDescontar.TabIndex = 16;
            this.btnDescontar.Text = "Descontar placas";
            this.btnDescontar.UseVisualStyleBackColor = false;
            this.btnDescontar.Click += new System.EventHandler(this.btnDescontar_click);
            // 
            // removeMode
            // 
            this.removeMode.AutoSize = true;
            this.removeMode.Location = new System.Drawing.Point(139, 20);
            this.removeMode.Name = "removeMode";
            this.removeMode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.removeMode.Size = new System.Drawing.Size(69, 17);
            this.removeMode.TabIndex = 15;
            this.removeMode.Text = "Remover";
            this.removeMode.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dataPalet);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 360);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // errorText
            // 
            this.errorText.BackColor = System.Drawing.Color.Black;
            this.errorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.errorText.Location = new System.Drawing.Point(10, 212);
            this.errorText.Multiline = true;
            this.errorText.Name = "errorText";
            this.errorText.ReadOnly = true;
            this.errorText.Size = new System.Drawing.Size(424, 92);
            this.errorText.TabIndex = 17;
            // 
            // formPaletizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 372);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formPaletizar";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paletizar";
            this.Load += new System.EventHandler(this.formPaletizar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataPalet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.DataGridView dataPalet;
        private System.Windows.Forms.TextBox detailPalet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboDestino;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox removeMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn _barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn _cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn _declarado;
        private System.Windows.Forms.Button btnDescontar;
        private System.Windows.Forms.TextBox errorText;
    }
}