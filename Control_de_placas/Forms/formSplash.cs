using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Control_de_placas
{
    public partial class formSplash : Form
    {
        public bool finalizar = true;

        public formSplash()
        {
            InitializeComponent();
        }

        private void formSplash_Load(object sender, EventArgs e)
        {
          
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F1))
            {
                Aplicacion.formMain.configuracionMenuItem_Click(null,null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aplicacion.loadconf();
            Mysql sql = new Mysql();
            DataTable login = sql.Select(@"SELECT 
            id
            ,turno
            ,operador
            ,acceso
            ,id_sector
            ,(
                SELECT sector from sector as s
                where s.id = id_sector 
            ) as sector

            FROM  `operadores` where clave = '" + inClave.Text + "' limit 1");

            if (login.Rows.Count > 0)
            {
                DataRow row = login.Rows[0];

                Operador.id_turno = row["turno"].ToString();
                Operador.turno = Global.normalizarTurno(Operador.id_turno);

                Operador.id = row["id"].ToString();
                Operador.operador = row["operador"].ToString();

                Operador.acceso = row["acceso"].ToString();

                Operador.id_sector = row["id_sector"].ToString();
                Operador.sector = row["sector"].ToString();

                inClave.Enabled = false;
                btn_acceder.Enabled = false;

                if (
                    Operador.acceso.Equals("O") ||
                    Operador.acceso.Equals("SP")
                    )
                {
                    // El servidor es el sector donde se encuentra el Operador/Supervisor
                    Operador.id_servidor = Operador.id_sector;
                    Operador.servidor = Operador.sector;

                    // Aplico filtro, muestro solo entradas del servidor seleccionado
                    Filtro.main.id_servidor = Operador.id_servidor;

                    finalizar = false;

                    Aplicacion.formMain.finalizarLogin();
                }
                else
                {
                    comboDestino.Items.Add(new Combo("Insercion Automatica", "2"));
                    comboDestino.Items.Add(new Combo("Insercion Manual", "1"));

                    comboDestino.SelectedIndex = 0;  
                    panel1.Visible = true;
                }
            }
            else
            {

                MessageBox.Show(
                    "Clave incorrecta.", 
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                inClave.Text = "";
            }
        }


        private void formSplash_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finalizar)
            {
                Application.Exit();
            }
            else
            {
                Aplicacion.formMain.Enabled = true;
            }
        }

        private void inClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button1_Click(sender, e);
            }
        }

        private void btn_server_Click(object sender, EventArgs e)
        {
            if (comboDestino.SelectedIndex >= 0)
            {
                Combo sector_sel = comboDestino.Items[comboDestino.SelectedIndex] as Combo;

                Operador.id_servidor = sector_sel.Valor.ToString();
                Operador.servidor = sector_sel.Nombre.ToString();

                // Aplico filtro, muestro solo entradas del servidor seleccionado
                Filtro.main.id_servidor = Operador.id_servidor;

                finalizar = false;
                Aplicacion.formMain.finalizarLogin();

            }
        }
    }
}
