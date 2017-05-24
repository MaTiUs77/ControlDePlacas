using Control_de_placas.Src.Config;
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
    public partial class formConfig : Form
    {
        public formConfig()
        {
            InitializeComponent();
        }
        private void formConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            Aplicacion.formConfig = null;
        }

        private void formConfig_Load(object sender, EventArgs e)
        {
            Aplicacion.formConfig = this;

            inServer.Text = AppConfig.Read("IASERVER", "db_host");
            inDatabase.Text = AppConfig.Read("IASERVER", "db_database");
            inUsuario.Text = AppConfig.Read("IASERVER", "db_user");
            inClave.Text = AppConfig.Read("IASERVER", "db_pass");

            inListas.Text = AppConfig.Read("IASERVER", "listas");
        }
        public void guardarConf() {
            AppConfig.Save("IASERVER", "db_host", inServer.Text);
            AppConfig.Save("IASERVER", "db_database", inDatabase.Text);
            AppConfig.Save("IASERVER", "db_user", inUsuario.Text);
            AppConfig.Save("IASERVER", "db_pass", inClave.Text);
            AppConfig.Save("IASERVER", "listas", inListas.Text);

            if (MessageBox.Show("Para cargar la nueva configuracion es necesario reiniciar la aplicacion. Reiniciar?", "Configuracion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Aplicacion.Restart();
            }
        }        

        private void guardarConfiguracioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardarConf();
        }
    }
}
