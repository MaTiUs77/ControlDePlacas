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
    public partial class formPaletizar : Form
    {

        public Palet palet = new Palet();
        private Form parent;
        private bool modeConfirm = false; 
 
        public formPaletizar(Form f)
        {
            parent = f;
            InitializeComponent();
        }

        private void formPaletizar_Load(object sender, EventArgs e)
        {
            fillSector();
            txtBarcode.Focus();
        }

        public void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (modeConfirm)
                {
                    PaletConfirm();
                }
                else
                {
                    StockerData();
                }
            }
        }

        public void AddToPalet(Stocker stk)
        {
            if (!palet.OnList(stk))
            {

                int index = dataPalet.Rows.Add(
                    stk.service.stocker.barcode,
                    stk.service.stocker.unidades
                );

                // Agrego indice de fila a stocker.
                stk.row = index;
                palet.AddToList(stk);

                // Carga modelo lote panel y op en palet 
                detailPalet.Text = string.Concat(
                    "Modelo: ",
                    stk.service.smt.modelo, 
                        System.Environment.NewLine, 
                    "Lote: ",
                    stk.service.smt.lote,
                        System.Environment.NewLine,
                    "Panel: ",
                    stk.service.smt.panel,
                        System.Environment.NewLine,
                    "Unidades: ",
                    palet.SumarUnidades());
                
            }
        }

        public void StockerData()
        {
            Stocker stocker = new Stocker();

            string inStockerCode = txtBarcode.Text.Trim().ToUpper();
            if (inStockerCode != "")
            {
                try
                {
                    stocker.getInfo(inStockerCode);
                    if (stocker.exception == null)
                    {
                        if (stocker.service.stocker.error == null)
                        {
                            if (stocker.service.stocker.unidades > 0)
                            {
                                if (!palet.started)
                                {
                                    // Cargo palet con datos de primer stocker.
                                    palet.Init(stocker);
                                    btnFinish.Enabled = true;
                                }

                                if (
                                    stocker.service.smt.modelo == palet.modelo &&
                                    stocker.service.smt.lote == palet.lote &&
                                    stocker.service.smt.panel == palet.panel &&
                                    stocker.service.stocker.op == palet.op
                                )
                                {
                                    AddToPalet(stocker);
                                }
                                else
                                {
                                    MessageBox.Show("Atencion, el stocker (" + stocker.service.stocker.barcode + ") tiene un modelo/op diferente.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("El stocker no contiene placas.");
                            }
                        } else
                        {
                            MessageBox.Show(stocker.service.stocker.error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(stocker.exception);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                // Una vez guardado el dato, procedo a liberar el stocker. 
                stocker = new Stocker();
                txtBarcode.Text = "";
                txtBarcode.Focus();
            }
        }

        // Cargar sectores
        public void fillSector()
        {
            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
                    SELECT
                        id,
                        sector,
                        visible
                    from sector
                    where visible = 1
                    order by sector desc                
                ");

            foreach (DataRow row in dt.Rows)
            {
                comboDestino.Items.Add(new Combo(row["sector"].ToString(), row["id"].ToString()));
            }
            // Selecciono el ultimo sector por defecto
            comboDestino.SelectedIndex = comboDestino.Items.Count - 1;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (!modeConfirm)
            {
                if (MessageBox.Show("Iniciar confirmacion de stockers?", "Iniciar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PaletConfirm();
                }
            }
            else
            {
                finish();
            }
        }

        private void PaletConfirm()
        {
            modeConfirm = true;
            btnFinish.Enabled = false;
            btnFinish.Text = "Completar operacion";
            txtBarcode.BackColor = System.Drawing.ColorTranslator.FromHtml("#8ff470");

            string inStockerCode = txtBarcode.Text.Trim().ToUpper();
            if (inStockerCode != "")
            {
                IEnumerable<Stocker> stocker = palet.stockerList.Where(s => s.service.stocker.barcode == inStockerCode );
                if (stocker.Count()>0) {
                    stockerSuccess(stocker.First());
                }
            }

            txtBarcode.Text = "";
            txtBarcode.Focus();
        }


        private void stockerSuccess(Stocker stocker) {
            stocker.confirm = true;

            dataPalet.Rows[stocker.row].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#8ff470");
            dataPalet.ClearSelection();

            if (palet.CountAll() == palet.CountConfirm())
            {
                btnFinish.Enabled = true;
                txtBarcode.Enabled = false;
            }
        }

        private void finish() {
            int id_destino = 0;
            if (comboDestino.SelectedIndex >= 0)
            {
                Combo cmb = comboDestino.Items[comboDestino.SelectedIndex] as Combo;
                id_destino = int.Parse(cmb.Valor.ToString());
            }

            // Inserto y reseteo formulario
            Sql.InsertarDato(palet.modelo, palet.lote, palet.panel, palet.SumarUnidades(), id_destino, palet.op, palet.barcode, palet.semielaborado);

            palet.enviarAll();

            Form1 form = parent as Form1;
            form.reloadMainGrid();
            this.Close();
        }
    }
}
