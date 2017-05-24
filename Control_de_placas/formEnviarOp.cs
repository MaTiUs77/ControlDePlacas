using Control_de_placas.IAServer;
using Control_de_placas.IAServer.Mapper;
using System;
using System.Data;
using System.Windows.Forms;

namespace Control_de_placas
{
    public partial class formEnviarOp : Form
    {
        private OPInfoMapper currentOp;
        private Form parent;

        public formEnviarOp(Form f)
        {
            parent = f;
            InitializeComponent();
        }

        private void formEnviarOp_Load(object sender, EventArgs e)
        {
            fillSector();
            inOp.Focus();
        }

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

        private void finish()
        {
            int id_destino = 0;
            if (comboDestino.SelectedIndex >= 0)
            {
                Combo cmb = comboDestino.Items[comboDestino.SelectedIndex] as Combo;
                id_destino = int.Parse(cmb.Valor.ToString());
            }

            if (!inCantidad.Text.Equals(""))
            {
                int cantidad = int.Parse(inCantidad.Text);
                // Inserto y reseteo formulario
                Sql.InsertarDato(
                    currentOp.smt.modelo,
                    currentOp.smt.lote,
                    currentOp.smt.panel, 
                    cantidad, id_destino,
                    currentOp.smt.op, 
                    "manual",
                    currentOp.wip.wip_ot.codigo_producto
                );

                Form1 form = parent as Form1;
                form.reloadMainGrid();
                this.Close();
            } else
            {
                MessageBox.Show("No ingreso la cantidad de placas a enviar");
            }
        }

        private void insertar_Click(object sender, EventArgs e)
        {
            finish();
        }

        private void inOp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFinish.Enabled = false;
                inCantidad.Enabled = false;

                currentOp = new OPInfoMapper();

                detailOp.Text = "";
                try
                {
                    ControlDePlacasService api = new ControlDePlacasService();
                    api.OPInfoApi(inOp.Text.ToString());

                    if (api.hasResponse)
                    {
                        if (api.opinfo.error == null)
                        {
                            #region OP INFO
                            if (api.opinfo.smt != null)
                            {
                                // Carga modelo lote panel y op en palet 
                                detailOp.Text = string.Concat(
                                    "OP: ",
                                    api.opinfo.smt.op,
                                        System.Environment.NewLine,
                                    "Modelo: ",
                                    api.opinfo.smt.modelo,
                                        System.Environment.NewLine,
                                    "Lote: ",
                                    api.opinfo.smt.lote,
                                        System.Environment.NewLine,
                                    "Panel: ",
                                    api.opinfo.smt.panel,
                                        System.Environment.NewLine,
                                    "Semielaborado: ",
                                    api.opinfo.wip.wip_ot.codigo_producto);

                                btnFinish.Enabled = true;
                                inCantidad.Enabled = true;

                                currentOp = api.opinfo;
                            }
                            else
                            {
                                btnFinish.Enabled = false;
                                inCantidad.Enabled = false;

                                currentOp = new OPInfoMapper();

                                detailOp.Text = "No fue posible obtener datos de OP";
                            }
                            #endregion
                        }
                        else
                        {
                            detailOp.Text = "Error: " + api.opinfo.error;
                        }
                    }
                    else
                    {
                        detailOp.Text = "Error: " + api.exception;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
