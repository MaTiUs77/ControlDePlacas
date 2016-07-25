﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control_de_placas
{
    public partial class formEnviarOp : Form
    {

        public OP op;
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
                Sql.InsertarDato(op.modelo, op.lote, op.panel, cantidad, id_destino, op.op, "manual", op.semielaborado);

                Form1 form = parent as Form1;
                form.reloadMainGrid();
                this.Close();
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
                op = new OP();
                op.getInfo(inOp.Text.ToString());

                if(op.modelo!=null)
                {
                    // Carga modelo lote panel y op en palet 
                    detailOp.Text = string.Concat(
                        "OP: ",
                        op.op,
                            System.Environment.NewLine,
                        "Modelo: ",
                        op.modelo,
                            System.Environment.NewLine,
                        "Lote: ",
                        op.lote,
                            System.Environment.NewLine,
                        "Panel: ",
                        op.panel,
                            System.Environment.NewLine,
                        "Semielaborado: ",
                        op.semielaborado);

                    btnFinish.Enabled = true;
                    inCantidad.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No fue posible obtener datos de OP");
                    btnFinish.Enabled = false;
                    inCantidad.Enabled = false;
                }


            }
        }
    }
}