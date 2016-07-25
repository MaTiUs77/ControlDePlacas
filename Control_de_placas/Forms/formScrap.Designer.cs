namespace Control_de_placas
{
    partial class formScrap
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridScrap = new System.Windows.Forms.DataGridView();
            this._id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._panel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._turno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filtroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridScrap)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridScrap
            // 
            this.gridScrap.AllowUserToAddRows = false;
            this.gridScrap.AllowUserToDeleteRows = false;
            this.gridScrap.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridScrap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridScrap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridScrap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._id,
            this._modelo,
            this._lote,
            this._panel,
            this._cantidad,
            this._total,
            this._turno,
            this._fecha,
            this._hora});
            this.gridScrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridScrap.Location = new System.Drawing.Point(0, 24);
            this.gridScrap.Name = "gridScrap";
            this.gridScrap.ReadOnly = true;
            this.gridScrap.RowHeadersVisible = false;
            this.gridScrap.Size = new System.Drawing.Size(591, 287);
            this.gridScrap.TabIndex = 0;
            // 
            // _id
            // 
            this._id.HeaderText = "ID";
            this._id.Name = "_id";
            this._id.ReadOnly = true;
            this._id.Visible = false;
            // 
            // _modelo
            // 
            this._modelo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._modelo.HeaderText = "Modelo";
            this._modelo.Name = "_modelo";
            this._modelo.ReadOnly = true;
            this._modelo.Width = 67;
            // 
            // _lote
            // 
            this._lote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._lote.HeaderText = "Lote";
            this._lote.Name = "_lote";
            this._lote.ReadOnly = true;
            this._lote.Width = 53;
            // 
            // _panel
            // 
            this._panel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._panel.HeaderText = "Panel";
            this._panel.Name = "_panel";
            this._panel.ReadOnly = true;
            this._panel.Width = 59;
            // 
            // _cantidad
            // 
            this._cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._cantidad.HeaderText = "Cantidad";
            this._cantidad.Name = "_cantidad";
            this._cantidad.ReadOnly = true;
            this._cantidad.Width = 74;
            // 
            // _total
            // 
            this._total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._total.HeaderText = "Total";
            this._total.Name = "_total";
            this._total.ReadOnly = true;
            this._total.Width = 56;
            // 
            // _turno
            // 
            this._turno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._turno.HeaderText = "Turno";
            this._turno.Name = "_turno";
            this._turno.ReadOnly = true;
            this._turno.Width = 60;
            // 
            // _fecha
            // 
            this._fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._fecha.HeaderText = "Fecha";
            this._fecha.Name = "_fecha";
            this._fecha.ReadOnly = true;
            this._fecha.Width = 62;
            // 
            // _hora
            // 
            this._hora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._hora.HeaderText = "Hora";
            this._hora.Name = "_hora";
            this._hora.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filtroToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(591, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filtroToolStripMenuItem
            // 
            this.filtroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem});
            this.filtroToolStripMenuItem.Image = global::Control_de_placas.Properties.Resources.magnifier;
            this.filtroToolStripMenuItem.Name = "filtroToolStripMenuItem";
            this.filtroToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.filtroToolStripMenuItem.Text = "Filtro";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // formScrap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 311);
            this.Controls.Add(this.gridScrap);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "formScrap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estado de Scrap";
            this.Load += new System.EventHandler(this.formScrap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridScrap)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridScrap;
        private System.Windows.Forms.DataGridViewTextBoxColumn _id;
        private System.Windows.Forms.DataGridViewTextBoxColumn _modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn _panel;
        private System.Windows.Forms.DataGridViewTextBoxColumn _cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn _total;
        private System.Windows.Forms.DataGridViewTextBoxColumn _turno;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn _hora;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filtroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
    }
}