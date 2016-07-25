using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Windows.Forms;

namespace Control_de_placas
{
    class Email
    {
        public string smtp = "ARRPEEX01.nwsn.local";
        public string de = "";
        public string para = "";
        public string nombre_de = "";
        public string mensaje = "";
        public void Enviar()
        {
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            try
            {
                m.From = new MailAddress(de, nombre_de);
                m.To.Add(new MailAddress(para, ""));
                //                m.CC.Add(new MailAddress("CC@yahoo.com", "Display name CC"));
                m.Subject = "";
                m.IsBodyHtml = true;
              
                
                m.Body = @"<html>
<body style=font-family:Arial;>
<h2>Control de Placas</h2>
Atencion! no se detecto la recepcion de los siguientes envios
<hr>
<table>
<tr><td style=text-align:right;>Codigo de Envio:</td><td style=font-weight:bold;> 13443 </td></tr>
<tr><td style=text-align:right;>Destino</td><td style=font-weight:bold;> Planta 5</td></tr>
<tr><td style=text-align:right;>Fecha</td><td style=font-weight:bold;> 23/01/2013</td></tr>
<tr><td style=text-align:right;>Hora</td><td style=font-weight:bold;> 15:46</td></tr>
<tr><td style=text-align:right;>Modelo</td><td style=font-weight:bold;>24LC823H</td></tr>
<tr><td style=text-align:right;>Lote</td><td style=font-weight:bold;>L114</td></tr>
<tr><td style=text-align:right;>Panel</td><td style=font-weight:bold;>POW</td></tr>
<tr><td style=text-align:right;>Cantidad</td><td style=font-weight:bold;>200</td></tr>
</table>
</body>
</html>";

                sc.Host = smtp;
//                sc.Port = 587;
//                sc.Credentials = new System.Net.NetworkCredential(de,"clavesecreta");
//                sc.EnableSsl = true;
                sc.Send(m);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
          
