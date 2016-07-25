using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Deployment.Application;
using System.Windows.Forms;
using System.IO;

namespace Control_de_placas
{
    class Aplicacion
    {
        public static Form1 formMain;

        public static int currentTab = 0;

        public static string currentDatoID = "";
        public static int currentMainID = 0;


        public static formNotas formNotas;
        public static formCalcularStoker formStoker;
        public static formConfig formConfig;
        public static formLotes formLotes;

        // Cargar configuracion
        public static void loadconf()
        {
            Ingenieria.PATH_LISTAS = Util.AppSettingValue("listas");

            // Cargo datos del servidor.
            Mysql.server = Util.AppSettingValue("mysql_server");
            Mysql.database = Util.AppSettingValue("mysql_database");
            Mysql.user = Util.AppSettingValue("mysql_user");
            Mysql.password = Util.AppSettingValue("mysql_pass");
        }

        // Verifica actualizaciones. 
        public static void update()
        {
            try
            {
                ApplicationDeployment deploy = ApplicationDeployment.CurrentDeployment;
                UpdateCheckInfo update = deploy.CheckForDetailedUpdate();
                if (deploy.CheckForUpdate())
                {
                    MessageBox.Show("Se detecto la version " + update.AvailableVersion.ToString() + ", se actualizara la aplicacion.");
                    deploy.Update();
                    Application.Restart();
                }
            }
            catch (Exception ex)
            {
                // Nada.... MessageBox.Show(ex.Message.ToString());
            }
        }

        public static void Restart()
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Application.Exit();
        }
    }
}
