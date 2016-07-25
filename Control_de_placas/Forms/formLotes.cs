using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control_de_placas
{
    public partial class formLotes : Form
    {
        public formLotes()
        {
            InitializeComponent();
        }

        private void formLotes_Load(object sender, EventArgs e)
        {
            Aplicacion.formLotes = this;
            Ingenieria.combo_Modelos(comboModelo);
            reloadMainGrid();
        }

        private void comboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboLote.Items.Clear();
            Combo modelo = comboModelo.Items[comboModelo.SelectedIndex] as Combo;
            Ingenieria.combo_Lotes(modelo.Valor.ToString(), comboLote);
            btGuardar.Enabled = true;
        }

        public void guardarSalida()
        {
  //          Combo cmModelo = comboModelo.Items[comboModelo.SelectedIndex] as Combo;
//            Combo cmLote = comboLote.Items[comboLote.SelectedIndex] as Combo;

            string dia = inFecha.Value.Day.ToString();
            string mes = inFecha.Value.Month.ToString();
            string anio = inFecha.Value.Year.ToString();

            string modelo = comboModelo.Text.ToString();// cmModelo.Nombre.ToString();
            string lote = comboLote.Text.ToString(); // cmLote.Nombre.ToString();
            string cantidad = inCantidad.Text.ToString();

            if ( 
                modelo.Equals("") || 
                lote.Equals("") || 
                cantidad.Equals("")
               )
            {
                MessageBox.Show("Los datos son invalidos.");
            }
            else
            {
                Mysql sql = new Mysql();

                DataTable existe = sql.Select("select modelo,lote from lotes where modelo = '" + modelo + "' and lote = '" + lote + "'");
                if (existe.Rows.Count > 0)
                {
                    MessageBox.Show("Atencion. Ya existe el lote: " + lote + " para el modelo: " + modelo);
                }
                else
                {
                    bool rs = sql.Ejecutar(@"
                INSERT INTO  `lotes` (
                    `id` , `modelo` , `lote` , `total` , `fecha` 
                ) VALUES (
                    NULL ,  '" + modelo + "  ',  '" + lote + "',  '" + cantidad + "',  '" + anio + "-" + mes + "-" + dia + "');");
                    if (!rs)
                    {
                        MessageBox.Show("Error.");
                    }
                }
            }
        }

        public void reloadMainGrid()
        {
            mainGrid.Rows.Clear();
            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
            SELECT 
            id,
            modelo,
            lote,
            total,
            DATE_FORMAT(fecha, '%d/%m/%Y') as fecha
            from lotes 
            order by modelo,fecha desc
            ");

            foreach (DataRow row in dt.Rows)
            {
                mainGrid.Rows.Add(
                    row["id"].ToString(),
                    row["modelo"].ToString(),
                    row["lote"].ToString(),
                    row["total"].ToString(),
                    row["fecha"].ToString()
                );
            }

            Aplicacion.formMain.reloadMainGrid();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            guardarSalida();
            reloadMainGrid();            
        }

        private void formLotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Aplicacion.formLotes = null;
        }

        private int currentMainID;
        private void mainGrid_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = mainGrid.HitTest(e.X, e.Y).RowIndex;
                int col = mainGrid.HitTest(e.X, e.Y).ColumnIndex;
                ContextMenu m = new ContextMenu();

                if (row >= 0 && col >= 0)
                {
                    currentMainID = row;
                    mainGrid.ClearSelection();
                    mainGrid.Rows[row].Cells[col].Selected = true;

                    m.MenuItems.Add(new MenuItem("Borrar", mainGrid_btBorrar));
                }
                m.Show(mainGrid, new Point(e.X, e.Y));
            }
        }

        private void mainGrid_btBorrar(object sender, EventArgs args)
        {
            if (MessageBox.Show("Confirma eliminar?. Modelo: " + mainGrid.Rows[currentMainID].Cells["modelo"].Value.ToString() + " Lote: " + mainGrid.Rows[currentMainID].Cells["lote"].Value.ToString() + " Total: " + mainGrid.Rows[currentMainID].Cells["total"].Value.ToString(), "Borrar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sqlString = "delete from lotes where id = '" + mainGrid.Rows[currentMainID].Cells["id"].Value.ToString() + "' limit 1";

                Mysql sql = new Mysql();
                bool rs = sql.Ejecutar(sqlString);
                if (rs)
                {
                    reloadMainGrid();
                }
                else
                {
                    MessageBox.Show("mainGrid_btBorrar(): Error al borrar.");
                }
            }
        }
    }
}
