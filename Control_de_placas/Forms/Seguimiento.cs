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
    public partial class Seguimiento : Form
    {
        public string modelo = "";
        public string lote = "";
        public string panel = "";

        public string total_lote = "";
        public string salidas = "";
        public string restantes = "";

        public Seguimiento()
        {
            InitializeComponent();
        }

        private void Seguimiento_Load(object sender, EventArgs e)
        {
            inTitulo.Text = modelo + " - " + lote;
            inTotal.Text = total_lote;
            inSalidas.Text = salidas;
            inRestantes.Text = restantes;

            comboPanel.Items.Add(panel);
            comboPanel.SelectedItem = panel;
        }
    }
}
