using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using GenCode128;
using System.Windows.Forms;
using Control_de_placas.Src.Config;

namespace Control_de_placas
{
    class ImprimirPedido
    {
        public string destino = "____________";
        public string modelo = "DESCONOCIDO";
        public string panel = "DESCONOCIDO";
        public string lote = "DESCONOCIDO";
        public string cantidad = "DESCONOCIDO";
        public string op = "DESCONOCIDO";
        public string fecha = "DESCONOCIDO";
        public string hora = "DESCONOCIDO";
        public string codigo = "DESCONOCIDO";
        public string semielaborado = "DESCONOCIDO";

        public string reproceso = null;
        public string reenvio = null;

        public bool previa = false;

        public void Imprimir()
        {
            PrintDialog pdialog = new PrintDialog();
            PrintDocument p = new PrintDocument();

            p.DocumentName = "CONTROL DE PLACAS";
            p.PrintPage += new PrintPageEventHandler(PrintReceiptPage);
            p.DefaultPageSettings.Landscape = true;

            pdialog.Document = p;

            DialogResult rs = pdialog.ShowDialog();

            if (rs == DialogResult.OK)
            {               
                p.PrinterSettings.PrinterName = pdialog.PrinterSettings.PrinterName;
                p.DefaultPageSettings.Landscape = true;
                p.PrinterSettings.DefaultPageSettings.Landscape = true;

                if (previa)
                {
                    PrintPreviewDialog d = new PrintPreviewDialog();
                    d.Document = p;
                    d.ShowDialog();
                }
                else
                {
                    p.Print();
                }
            }           
        }

        public void PrintReceiptPage(object sender, PrintPageEventArgs e)
        {
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
//            e.PageSettings.Landscape = true;

            Font Titulo = new Font("Arial", 72, FontStyle.Bold);
            Font font_celda_var = new Font("Arial", 16, FontStyle.Regular);
            Font font_celda_valor = new Font("Arial", 24, FontStyle.Bold);
            Font font_destino = new Font("Arial", 12, FontStyle.Underline);
            Font font_fechahora = new Font("Arial", 12, FontStyle.Regular);
            Font font_fechahora_valor = new Font("Arial", 12, FontStyle.Bold);
            Font font_codigo = new Font("Arial", 24, FontStyle.Bold);
            Pen linea = new Pen(Color.Black);
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;
            StringFormat strFormatCenter = new StringFormat();
            strFormatCenter.Alignment = StringAlignment.Center;
            StringFormat strFormatRight = new StringFormat();
            strFormatRight.Alignment = StringAlignment.Far;
            StringFormat strFormatLeft = new StringFormat();
            strFormatLeft.Alignment = StringAlignment.Near;

            string zebra = AppConfig.Read("IASERVER","zebra");

            float x = leftMargin;
            float y = topMargin;

            float ancho = e.PageSettings.PrintableArea.Height;
            float alto = e.PageSettings.PrintableArea.Width;
            float celda_variable = (ancho / 2) - 250;
            float celda_valor = celda_variable + 250;

            if (reproceso != null)
            {
                e.Graphics.DrawString("SOLICITUD DE REPROCESO", font_fechahora_valor, Brushes.Black, new RectangleF(0, y, ancho, alto), strFormat);
                y += 20;
            }

            if (reenvio != null)
            {
                e.Graphics.DrawString("FINALIZACION DE REPROCESO", font_fechahora_valor, Brushes.Black, new RectangleF(0, y, ancho, alto), strFormat);
                y += 20;
            }

            e.Graphics.DrawString("DESTINO", font_destino, Brushes.Black, new RectangleF(0, y, ancho, alto), strFormat);
            y += 20;
            e.Graphics.DrawString(destino, Titulo, Brushes.Black, new RectangleF(0, y, ancho, alto), strFormat);

            y += 100;
            e.Graphics.DrawLine(linea, 0, y, ancho, y);
            y += 20;

            if (reproceso != null)
            {
                e.Graphics.DrawString("SOLICITANTE:", font_celda_var, Brushes.Black, new RectangleF(celda_variable, y, 250, 50), strFormatRight);
                e.Graphics.DrawString(reproceso, font_celda_valor, Brushes.Black, new RectangleF(celda_valor, y - 8, 300, 50), strFormatLeft);
                y += 50;
            }

            MatrixCode mc = new MatrixCode();
            Image code = mc.make(op + "[ENTER]" + semielaborado + "[ENTER]PLA[ENTER]" + cantidad + "[ENTER]"+zebra, 5, 1);
            e.Graphics.DrawImage(code, 250, y+30);

            e.Graphics.DrawString("MODELO:", font_celda_var, Brushes.Black, new RectangleF(celda_variable, y, 250, 50), strFormatRight);
            e.Graphics.DrawString(modelo, font_celda_valor, Brushes.Black, new RectangleF(celda_valor, y - 8, 300, 50), strFormatLeft);

            y += 50;

            e.Graphics.DrawString("PANEL:", font_celda_var, Brushes.Black, new RectangleF(celda_variable, y, 250, 50), strFormatRight);
            e.Graphics.DrawString(panel, font_celda_valor, Brushes.Black, new RectangleF(celda_valor, y - 8, 300, 50), strFormatLeft);

            y += 50;

            e.Graphics.DrawString("LOTE:", font_celda_var, Brushes.Black, new RectangleF(celda_variable, y, 250, 50), strFormatRight);
            e.Graphics.DrawString(lote, font_celda_valor, Brushes.Black, new RectangleF(celda_valor, y - 8, 300, 50), strFormatLeft);

            y += 50;

            e.Graphics.DrawString("CANTIDAD:", font_celda_var, Brushes.Black, new RectangleF(celda_variable, y, 250, 50), strFormatRight);
            e.Graphics.DrawString(cantidad, font_celda_valor, Brushes.Black, new RectangleF(celda_valor, y - 8, 300, 50), strFormatLeft);

            y += 50;

            e.Graphics.DrawString("OP:", font_celda_var, Brushes.Black, new RectangleF(celda_variable, y, 250, 50), strFormatRight);
            e.Graphics.DrawString(op, font_celda_valor, Brushes.Black, new RectangleF(celda_valor, y - 8, 300, 50), strFormatLeft);

            y += 40;
            e.Graphics.DrawLine(linea, 0, y, ancho, y);
            y += 10;
            float topbar = y;
 
            y += 30;
            Image barra = Code128Rendering.MakeBarcodeImage(codigo, 5, 100, true);
            float centro = (ancho / 2) - (barra.Width / 2);
            e.Graphics.DrawImage(barra, centro, y);
            y += barra.Height + 10;

            e.Graphics.DrawString(codigo, font_codigo, Brushes.Black, new RectangleF(0, y, ancho, 50), strFormatCenter);

            e.Graphics.DrawString("FECHA:", font_fechahora, Brushes.Black, new RectangleF((ancho / 2) - 200, topbar, 100, 50), strFormatCenter);
            e.Graphics.DrawString(fecha, font_fechahora_valor, Brushes.Black, new RectangleF((ancho / 2) - 115, topbar, 150, 50), strFormatLeft);

            e.Graphics.DrawString("HORA:", font_fechahora, Brushes.Black, new RectangleF((ancho / 2) + 50, topbar, 100, 50), strFormatCenter);
            e.Graphics.DrawString(hora, font_fechahora_valor, Brushes.Black, new RectangleF((ancho / 2) + 25, topbar, 150, 50), strFormatRight);
        }
    }
}
