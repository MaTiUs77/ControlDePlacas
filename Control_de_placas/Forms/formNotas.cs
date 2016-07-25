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
    public partial class formNotas : Form
    {
        public string id_dato = "";
        public string flag = "N";

        public formNotas()
        {
            InitializeComponent();
        }

        private void formNotas_Load(object sender, EventArgs e)
        {
//            label.Text = id_dato;
            Aplicacion.formNotas = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nota = inNota.Text;

            if (nota.Equals(""))
            {
                MessageBox.Show("No redacto la nota a guardar...");
            }
            else
            {
                Mysql sql = new Mysql();
                bool rs = sql.Ejecutar(@"INSERT INTO `notas` (`id`, `id_operador`,`id_dato`, `nota`, `fecha`, `hora`, `flag`) VALUES (NULL, '" + Operador.id + "', '" + this.id_dato + "', '" + nota + "', CURDATE(), CURTIME(),'"+flag+"');");
                if (rs)
                {
                    inNota.Text = "";
                    Aplicacion.formMain.reloadMainGrid();
                    Aplicacion.formMain.reloadNotas(id_dato, flag);
                    this.Close();
                } 
                else 
                {
                    MessageBox.Show("Error al insertar nota.");
                }
            }
        }

        private void formNotas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Aplicacion.formNotas = null;
        }
    }
}
