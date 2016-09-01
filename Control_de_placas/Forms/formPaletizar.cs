using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_de_placas
{
    public partial class formPaletizar : Form
    {

        public Palet palet = new Palet();
        private Form parent;
        private bool modeConfirm = false;

        private TextBox errorLog;
 
        public formPaletizar(Form f)
        {
            parent = f;
            InitializeComponent();
        }

        private void formPaletizar_Load(object sender, EventArgs e)
        {
            errorLog = errorText;

            palet.dataPalet = dataPalet;
            palet.detailPalet = detailPalet;
            fillSector();
            txtBarcode.Focus();

            dataPalet.RowsDefaultCellStyle.SelectionBackColor = Color.Transparent;
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
                    string inStockerCode = txtBarcode.Text.Trim().ToUpper();

                    if (removeMode.Checked)
                    {
                        palet.RemoveFromList(inStockerCode);

                        dataPalet.ClearSelection();
                        txtBarcode.Text = "";
                        txtBarcode.Focus();
                    } else
                    {
                        StockerData();
                    }
                }
            }
        }

        public void StockerData()
        {
            Stocker stk = new Stocker();

            string inStockerCode = txtBarcode.Text.Trim().ToUpper();
            if (inStockerCode != "" && !palet.OnList(inStockerCode) && inStockerCode.StartsWith("STK"))
            {
                try
                {
                    stk.getInfo(inStockerCode);
                    if (stk.exception == null)
                    {
                        if (stk.info.error == null)
                        {
                            if (stk.info.stocker.unidades > 0)
                            {
                                if (!palet.started)
                                {
                                    // Cargo palet con datos de primer stocker.
                                    palet.Init(stk);
                                    btnFinish.Enabled = true;
                                }

                                if (
                                    stk.info.smt.modelo == palet.modelo &&
                                    stk.info.smt.lote == palet.lote &&
                                    stk.info.smt.panel == palet.panel &&
                                    stk.info.stocker.op == palet.op
                                )
                                {
                                    palet.AddToPalet(stk);
                                }
                                else
                                {
                                    //MessageBox.Show("Atencion, el stocker (" + stk.info.stocker.barcode + ") tiene un modelo/op diferente.");
                                    errorLog.Text = "Atencion, el stocker (" + stk.info.stocker.barcode + ") tiene un modelo/op diferente.";
                                }
                            }
                            else
                            {
                                //MessageBox.Show("El stocker no contiene placas.");
                                errorLog.Text = "El stocker no contiene placas.";
                            }
                        } else
                        {
                            //MessageBox.Show(stk.info.error);
                            errorLog.Text = stk.info.error;
                        }
                    }
                    else
                    {
//                        MessageBox.Show(stk.exception);
                        errorLog.Text = stk.exception;
                    }
                }
                catch (Exception ex)
                {
//                    MessageBox.Show(ex.Message);
                    errorLog.Text = ex.Message;
                }

                // Una vez guardado el dato, procedo a liberar el stocker. 
                stk = new Stocker();
            }

            txtBarcode.Text = "";
            txtBarcode.Focus();
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

        private void btnDescontar_click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Realmente quiere descontar placas del stocker?", "Descontar placas", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                string promptValue = Prompt.ShowDialog("Ingrese la cantidad a descontar", "Descontar placas");
                try
                {
                    palet.scrap = int.Parse(promptValue);
                    if (palet.SumarUnidades() > 0)
                    {
                        palet.StockerResume();
                    }
                    else
                    {
                        palet.scrap = 0;
                        MessageBox.Show("No se descuentan las placas, porque da un numero negativo");
                        errorLog.Text = "No se descuentan las placas, porque da un numero negativo";
                    }
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    errorLog.Text = ex.Message;
                }
            }
        }

        private void PaletConfirm()
        {
            if (palet.CountAll() > 0 && palet.CountAll() == palet.CountDeclared())
            {
                removeMode.Visible = false;

                modeConfirm = true;
                btnFinish.Enabled = false;
                btnFinish.Text = "Completar operacion";
                txtBarcode.BackColor = ColorTranslator.FromHtml("#8ff470");

                string inStockerCode = txtBarcode.Text.Trim().ToUpper();
                if (inStockerCode != "")
                {
                    IEnumerable<Stocker> stocker = palet.stockerList.Where(s => s.info.stocker.barcode == inStockerCode );
                    if (stocker.Count()>0) {
                        stockerSuccess(stocker.First());
                    }
                }
            } else
            {
                removeMode.Visible = true;
                MessageBox.Show("No se puede iniciar confirmacion, hay stockers con placas sin declarar en la lista.");
                errorLog.Text = "No se puede iniciar confirmacion, hay stockers con placas sin declarar en la lista.";
            }

            txtBarcode.Text = "";
            txtBarcode.Focus();
        }

        private void stockerSuccess(Stocker stocker) {
            if(stocker.isDeclared)
            {
                stocker.confirm = true;

                dataPalet.Rows[stocker.row].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#8ff470");
                dataPalet.ClearSelection();

                if (palet.CountAll() == palet.CountConfirm())
                {
                    btnFinish.Enabled = true;
                    txtBarcode.Enabled = false;
                }
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
