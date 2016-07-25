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
    public partial class formInformeDiario : Form
    {
        private BackgroundWorker bw = new BackgroundWorker();

        public formInformeDiario()
        {
            InitializeComponent();
        }

        private void formInformeDiario_Load(object sender, EventArgs e)
        {
        }

        private void IniaddRow()
        {
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(loadsql);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }

        private delegate void dlg_addRow(string fecha,string modelo,string lote,string placa, string txt);
        private void dlg_dt_addRow(string fecha,string modelo,string lote,string placa, string txt)
        {
            dataGridView1.Rows.Add(fecha,modelo,lote,placa,txt);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Completo");
        }

        private List<string> splitChar(string value)
        {
            List<string> i = new List<string>();
            foreach (char c in value)
            {
                i.Add(c.ToString());
            }
            return i;
        }

        private void loadsql(object sender, DoWorkEventArgs e)
        {
            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
SELECT fecha, modelo, lote, placa
FROM  `datos` 

GROUP BY modelo, lote, placa
ORDER BY modelo DESC

");
            foreach (DataRow row in dt.Rows)
            {

                string fechaz = row["fecha"].ToString();
                string modelo = row["modelo"].ToString();
                string lote = row["lote"].ToString();
                string placa = row["placa"].ToString();

                DataTable info = Ingenieria.getInfo(modelo, lote);
                List<string> pcblist = new List<string>();

                bool done = false;

                if (info.Rows.Count > 0) // si existe Modelo, Lote
                {
                    pcblist.Clear();
                    pcblist = Ingenieria.getPCB(info); // Obtener paneles

                    foreach (string lpcb in pcblist) // verificar con cada panel del lote
                    {
                        if (placa == lpcb)
                        {
                            done = true;
                        } 
                        else 
                        {
                            if (!lpcb.Equals("") && placa.Contains(lpcb))
                            {
                                done = true;
                                if (InvokeRequired)
                                {
                                    Invoke(new dlg_addRow(dlg_dt_addRow), fechaz, modelo, lote, placa, lpcb);
                                }
                            }
                        }
                    }

                    if (!done)
                    {
                        List<string> lsls = pcblist.FindAll(p => p.StartsWith(placa.Substring(0,1)));


                        if (InvokeRequired)
                        {
                            Invoke(new dlg_addRow(dlg_dt_addRow), fechaz, modelo, lote, placa,String.Join("-", lsls ));
                            done = true;
                        }
                    }
                }
                else
                {
                    if (InvokeRequired)
                    {
                        Invoke(new dlg_addRow(dlg_dt_addRow), fechaz, modelo, lote, placa, "ERROR");
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            IniaddRow();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                string modelo = r.Cells["modelo"].Value.ToString();
                string lote = r.Cells["lote"].Value.ToString();
                string placa = r.Cells["placa"].Value.ToString();
                string lista = r.Cells["lista"].Value.ToString();


                Mysql sql = new Mysql();
                bool rs = sql.Ejecutar("update datos set placa = '"+lista+"' where modelo = '"+modelo+"' and lote = '"+lote+"' and placa = '"+placa+"' ");
                if (!rs)
                {
                    MessageBox.Show("Error al actualizar.");
                }
            }

//            dataGridView1.Rows.Clear();
            //IniaddRow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bw.CancelAsync();
        }
    }
}