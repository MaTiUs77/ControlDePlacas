using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Deployment.Application;

namespace Control_de_placas
{
    public partial class formAcercade : Form
    {
        public formAcercade()
        {
            InitializeComponent();
        }

        private void formAcercade_Load(object sender, EventArgs e)
        {
            try
            {
                ApplicationDeployment deploy = ApplicationDeployment.CurrentDeployment;
                versionLabel.Text = deploy.CurrentVersion.ToString();
            }
            catch (Exception ex) { 
            
            }
        }
    }
}
