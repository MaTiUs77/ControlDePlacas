using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Control_de_placas
{
    public class Global
    {
        public static bool isNumber(string num) {
            Regex regex = new Regex(@"^[0-9]+$");
            if (regex.IsMatch(num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Comun en mainGrid
        public static void mainGrid_colour(DataGridViewRow row, string restantes)
        {
            string color = "";
            // Si no existen restantes == no existe lote.        
            if (!restantes.Equals(string.Empty))
            {
                if (int.Parse(restantes) > 0) // Si el lote es sobrepasado...
                {
                    color = "#FF5252"; //rojo
                }
                else if (int.Parse(restantes) == 0) // Si el lote fue finalizado
                {                    
                    color = "#BBFF00"; //verde
                }
            }
            else // Lote sin cargar
            {               
                color = "#000000"; // Negro
                row.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            }
            row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(color);
        }

        public static string normalizarTurno(string turno)
        {
            switch (turno)
            {
                case "1":
                    turno = "Mañana";
                    break;
                case "2":
                    turno = "Tarde";
                    break;
                case "3":
                    turno = "Noche";
                    break;
            }
            return turno;
        }
    }
}
