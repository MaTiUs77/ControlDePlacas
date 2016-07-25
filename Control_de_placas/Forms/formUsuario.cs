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
    public partial class formUsuario : Form
    {
        public formUsuario()
        {
            InitializeComponent();
        }

        private void formUsuario_Load(object sender, EventArgs e)
        {
            inTurno.Items.Add(new Combo("Mañana","1"));
            inTurno.Items.Add(new Combo("Tarde", "2"));
            inTurno.Items.Add(new Combo("Noche", "3"));
            inTurno.SelectedIndex = 0;
            
            loadUsuarios();


        }

        public void loadUsuarios() 
        {
            gridUsuario.Rows.Clear();
            Mysql sql = new Mysql();
            DataTable dt = sql.Select("Select id,operador,turno from operadores where acceso = 'O' ");

            foreach (DataRow r in dt.Rows)
            {
                gridUsuario.Rows.Add(
                    r["id"].ToString(),
                    r["operador"].ToString(),
                    Global.normalizarTurno(r["turno"].ToString()),"Editar","Eliminar"
                );
            }
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            string nombre = inNombre.Text;
            string clave = inClave.Text;
            string turno = (((Combo)inTurno.Items[inTurno.SelectedIndex]).Valor).ToString();

            string acceso = "O";
            if (nombre == "" || clave == "" || turno == "")
            {
                MessageBox.Show("Error al agregar. Verifique los datos.");
            }
            else
            {
                Mysql sql = new Mysql();
                DataTable dt = sql.Select("select operador from operadores where operador = '"+nombre+"' limit 1");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Error: Ya existe un usuario con ese nombre!");
                }
                else
                {
                    bool rs = sql.Ejecutar(@"
INSERT INTO  `placas_smd`.`operadores` (
`id` ,
`turno` ,
`operador` ,
`clave` ,
`acceso`
)
VALUES (
NULL ,  '"+turno+"',  '"+nombre+"',  '"+clave+"',  '"+acceso+"');");
                    if (rs)
                    {
                        MessageBox.Show("Agregado con exito.");

                        inNombre.Text = "";
                        inClave.Text = "";

                        loadUsuarios();
                    }
                }
            }
        }
    }
}
