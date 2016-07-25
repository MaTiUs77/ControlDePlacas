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
    public partial class formCalcularStoker : Form
    {
        public formCalcularStoker()
        {
            InitializeComponent();
        }

        private void formCalcularStoker_Load(object sender, EventArgs e)
        {
            Aplicacion.formStoker = this;
        }
        private void formCalcularStoker_FormClosed(object sender, FormClosedEventArgs e)
        {
            Aplicacion.formStoker = null;
        }


        private void button1_Click(object sender, EventArgs e)
        {
//            Aplicacion.formMain.setCantidad(CalcularStokers());
        }
        private string CalcularStokers()
        {
            string rs = "";

            int vSTOKERS =  0;
            int vCSTOKER = 0;
            int vMULTIPLOS = 0;
            string[] vINCOMPLETOS = null;

            bool calcular = false;
            bool suminc = false;

            int total_incompletos = 0;
            int total_completos = 0;

            int conteo = 0;

            try
            {
                vSTOKERS = int.Parse(inStokers.Text);
                vCSTOKER = int.Parse(inCstokers.Text);
                vMULTIPLOS = int.Parse(inBloques.Text);

                calcular = true;
            }
            catch
            {
                MessageBox.Show("Faltan valores para realizar el calculo.");
                calcular = false;
            }

            if (!inInc.Text.Equals(string.Empty))
            {            
                vINCOMPLETOS = inInc.Text.Split(',');
                suminc = true;
            }

            if (calcular)
            {
                if (suminc)
                {
                    if (vINCOMPLETOS.Count() > vSTOKERS)
                    {
                        MessageBox.Show("La cantidad de stokers es menor a los stokers incompletos.");
                    }
                    else
                    {
                        foreach (string numInc in vINCOMPLETOS)
                        {
                            total_incompletos = total_incompletos + int.Parse(numInc);
                            conteo++;
                        }
                    }
                }
                total_incompletos = (total_incompletos * vMULTIPLOS);
                total_completos = (vSTOKERS - conteo) * vCSTOKER * vMULTIPLOS;
                rs = (total_completos + total_incompletos).ToString();
            }
            return rs;
        }



    }
}
