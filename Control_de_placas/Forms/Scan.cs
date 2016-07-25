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
    public partial class Scan : Form
    {
        public string codigo = "";

        public Scan()
        {
            InitializeComponent();
        }

        private void recepcionScan_Load(object sender, EventArgs e)
        {
            in_codigo.Focus();
        }

        private void inKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                codigo = in_codigo.Text;

                if (!codigo.Equals(""))
                {
                    this.Close();
                }
            }
        }
    }
}
