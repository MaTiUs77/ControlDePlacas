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
    public partial class formFiltro : Form
    {
        public Filtro filtro = new Filtro();

        private Form parent;

        private bool scrap = false;
        private bool main = false;

        public formFiltro(Form f)
        {
            parent = f;
            InitializeComponent();
        }

        private void formFiltro_Load(object sender, EventArgs e)
        {
            // FILTRO DE SCRAP
            if (parent.GetType().ToString() == typeof(formScrap).ToString())  { scrap = true; }

            // FILTRO FORM MAIN
            if (parent.GetType().ToString() == typeof(Form1).ToString()) { main = true; }

            if (scrap)
            {
                this.Width = 180;
            }

            if (Aplicacion.currentTab == 1)
            {
                lblDestino.Text = "Solicitante";
                lblEstado.Visible = false;
                comboRecepcion.Visible = false;
            }

            if (Operador.acceso.Equals("R"))
            {
                labelEbs.Visible = false;
                comboEbs.Visible = false;                
            }

            Iniciar();
        }

        private void Iniciar() {
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

            comboModelo.SelectedText = filtro.modelo;
            comboLote.SelectedText = filtro.lote;
            comboPlaca.SelectedText = filtro.placa;

            fillSector();

            comboRecepcion.Items.Add(new Combo("Pendiente", "P"));
            comboRecepcion.Items.Add(new Combo("Recepcionado", "R"));


            comboEbs.Items.Add(new Combo("Pendiente", "0"));
            comboEbs.Items.Add(new Combo("Cargado", "1"));
        }
        
        private void btGuardar_Click(object sender, EventArgs e)
        {
            generarFiltro();

            // FILTRO FORM MAIN
            if (main)
            {
                Form1 form = parent as Form1;
                form.aplicarFiltro(filtro); // Devuelvo el filtro nuevo.
            }

            // FILTRO DE SCRAP
            if (scrap)
            {
                formScrap form = parent as formScrap;
                form.aplicarFiltro(filtro); // Devuelvo el filtro nuevo.
            }
        }

        public void generarFiltro()
        {
            filtro.id = "";
            filtro.modelo = comboModelo.Text;
            filtro.lote = comboLote.Text;
            filtro.placa= comboPlaca.Text;
            filtro.desde = FechaDesde.Value.Year + "-" + FechaDesde.Value.Month + "-" + FechaDesde.Value.Day;
            filtro.hasta= FechaHasta.Value.Year + "-" + FechaHasta.Value.Month + "-" + FechaHasta.Value.Day;
            filtro.id_destino = "";
            filtro.recepcion = "";
            filtro.ebs = "";
            filtro.op = txtOp.Text;

            if (comboDestino.SelectedIndex >= 0)
            {
                Combo d_destino = comboDestino.Items[comboDestino.SelectedIndex] as Combo;
                filtro.id_destino = d_destino.Valor;
            }

            if (comboRecepcion.SelectedIndex >= 0)
            {
                Combo c_recepcion = comboRecepcion.Items[comboRecepcion.SelectedIndex] as Combo;
                filtro.recepcion = c_recepcion.Valor;
            }

            if (comboEbs.SelectedIndex >= 0)
            {
                Combo c_ebs = comboEbs.Items[comboEbs.SelectedIndex] as Combo;
                filtro.ebs = c_ebs.Valor;
            }

            if (lblDestino.Text.Equals("Solicitante"))
            {
                filtro.id_solicitante = filtro.id_destino;
            }

        }
        private void btLimpiar_Click(object sender, EventArgs e)
        {
            // Reset;
            comboModelo.Text = "";
            comboLote.Text = "";
            comboPlaca.Text = "";
            FechaDesde.Value = DateTime.Now;
            FechaHasta.Value = DateTime.Now;
            comboDestino.SelectedIndex = -1;
            comboRecepcion.SelectedIndex = -1;
            comboEbs.SelectedIndex = -1;
            txtOp.Text = "";

            filtro.id = "";
            filtro.modelo = "";
            filtro.lote = "";
            filtro.placa= "";
            filtro.desde= FechaDesde.Value.Year + "-" + FechaDesde.Value.Month + "-" + FechaDesde.Value.Day;
            filtro.hasta= FechaHasta.Value.Year + "-" + FechaHasta.Value.Month + "-" + FechaHasta.Value.Day;
            filtro.id_destino = "";
            filtro.recepcion = "";
            filtro.ebs = "";
            filtro.op = "";

            if (lblDestino.Text.Equals("Solicitante"))
            {
                filtro.id_solicitante = "";
            }

            btGuardar_Click(sender,e);
        }

        private void comboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboModeloChanged();
        }
        public bool comboModeloChanged()
        {
            if (comboModelo.SelectedIndex >= 0)
            {
                comboLote.Items.Clear();
                comboPlaca.Items.Clear();
                Mysql sql = new Mysql();
                DataTable dt = sql.Select(@"
                    SELECT
                    DISTINCT(d.lote)
                    from datos d
                    where d.modelo = '" + comboModelo.Text+ @"'
                    group by d.lote
                    order by d.lote desc
                ");

                foreach (DataRow row in dt.Rows)
                {
                    comboLote.Items.Add(row["lote"].ToString());
                }

                fillPlacas();
            }
            return true;
        }

        public bool fillPlacas()
        {
            comboPlaca.Items.Clear();
            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
                    SELECT
                    DISTINCT(d.placa)
                    from datos d
                    where d.modelo = '" + comboModelo.Text + @"'
                    group by d.placa
                    order by d.placa asc
                ");

            foreach (DataRow row in dt.Rows)
            {
                comboPlaca.Items.Add(row["placa"].ToString());
            }
            return true;
        }
        public void fillSector()
        {
            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
                    SELECT
                    id,sector
                    from sector
                    order by sector desc
                ");

            foreach (DataRow row in dt.Rows)
            {
                comboDestino.Items.Add(new Combo(row["sector"].ToString(), row["id"].ToString()));
            }
        }
    }
}
