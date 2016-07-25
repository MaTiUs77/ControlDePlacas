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
    public partial class formSolicitarReproceso : Form
    {
        public bool completo = false;
        public string modelo = "";
        public string lote = "";
        public string panel = "";
        public string cantidad = "";
        public string destino = "2";
 
        public formSolicitarReproceso()
        {
            InitializeComponent();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            modelo = comboModelo.Text;
            lote = comboLote.Text;
            panel = comboPlaca.Text;
            cantidad = inCantidad.Text;

            if (
                modelo.Equals("") || lote.Equals("") || panel.Equals("") || cantidad.Equals("")
            )
            {
                MessageBox.Show("No completo todos los campos!");
            }
            else
            {
                completo = true;
                this.Close();
            }
        }

        public void cargarModelos() {
            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
SELECT
DISTINCT(d.modelo)
from datos d
group by d.modelo
order by d.modelo asc
");

            foreach (DataRow row in dt.Rows)
            {
                comboModelo.Items.Add(row["modelo"].ToString());
            }
        }

        private void formSolicitarReproceso_Load(object sender, EventArgs e)
        {
            cargarModelos();
        }

        private void comboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboModeloChanged();
        }

        private void comboLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboLoteChanged();
        }

        public bool comboModeloChanged()
        {
            comboLote.Items.Clear();
            comboPlaca.Items.Clear();

            comboLote.Text = "";
            comboPlaca.Text = "";

            if (comboModelo.SelectedIndex >= 0)
            {


                Mysql sql = new Mysql();
                DataTable dt = sql.Select(@"
                    SELECT
                    DISTINCT(d.lote)
                    from datos d
                    where d.modelo = '" + comboModelo.Text + @"'
                    group by d.lote
                    order by d.lote desc
                ");

                foreach (DataRow row in dt.Rows)
                {
                    comboLote.Items.Add(row["lote"].ToString());
                }
            }
            return true;
        }

        public bool comboLoteChanged()
        {
            comboPlaca.Items.Clear();
            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
                    SELECT
                    DISTINCT(d.placa)
                    from datos d
                    where d.modelo = '" + comboModelo.Text + @"' and d.lote = '"+comboLote.Text+@"'
                    group by d.placa
                    order by d.placa asc
                ");

            foreach (DataRow row in dt.Rows)
            {
                comboPlaca.Items.Add(row["placa"].ToString());
            }
            return true;
        }
    }
}
