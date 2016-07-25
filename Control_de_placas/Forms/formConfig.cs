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
            inServer.Text = Util.AppSettingValue("mysql_server");
            inDatabase.Text = Util.AppSettingValue("mysql_database");
            inUsuario.Text = Util.AppSettingValue("mysql_user");
            inClave.Text = Util.AppSettingValue("mysql_pass");

            inListas.Text = Util.AppSettingValue("listas");
        }
        public void guardarConf() {
            Util.AppSettingSave("mysql_server", inServer.Text);
            Util.AppSettingSave("mysql_database", inDatabase.Text);
            Util.AppSettingSave("mysql_user", inUsuario.Text);
            Util.AppSettingSave("mysql_pass", inClave.Text);
            Util.AppSettingSave("listas", inListas.Text);

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
