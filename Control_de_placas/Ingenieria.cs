using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;

namespace Control_de_placas
{
    public static class Ingenieria
    {
        public static string PATH_LISTAS =  "";
        public static char LOTE_SEPARADOR = '\t';

        public static string[] getModelos()
        {
            string[] lista = {};
           
            if (Directory.Exists(PATH_LISTAS))
            {
                lista = Directory.GetDirectories(PATH_LISTAS);
            }
            else
            {
                MessageBox.Show("No hay acceso a la carpeta listas.");
            }
           return lista;
        }
        public static List<string> getLotes(string url)
        {
            FileInfo[] files = new DirectoryInfo(url).GetFiles("*.txt");

            List<string> ls = new List<string>();

            if (files.Length > 0)
            {
                var lotes_array = files.OrderByDescending(f => f.Name);

                foreach (FileInfo lote_txt in lotes_array)
                {
                    var lote = lote_txt.ToString();
                    ls.Add(lote);
                }
            }
            return ls;
        }

        public static bool combo_Modelos(ComboBox combo)
        {
            combo.Items.Clear();

            string[] listaModelos = getModelos();
            foreach (string carpeta in listaModelos)
            {
                combo.Items.Add(new Combo(Path.GetFileNameWithoutExtension(carpeta),carpeta));
            }
            return true;
        }
        public static bool combo_Lotes(string modelo_path,ComboBox combo)
        {
            combo.Items.Clear();
            List<string> dt = getLotes(modelo_path);

            foreach (string lote in dt)
            {
                combo.Items.Add(new Combo(Path.GetFileNameWithoutExtension(lote), modelo_path+@"\"+lote));
            }
            return true;
        }
        public static bool combo_Placas(DataTable dt, ComboBox combo)
        {
            combo.Items.Clear();

//            List<Componentes> pcb = new List<Componentes>();

            List<string> pcblist = new List<string>();
            pcblist = Ingenieria.getPCB(dt);

            foreach(string panel in pcblist) {
                combo.Items.Add(panel);
            }

            /*
            foreach (DataRow row in dt.Rows)
            {
                string panel = row.ItemArray[4].ToString();
                string pos = row.ItemArray[5].ToString();
                string desc = row.ItemArray[6].ToString();
                string asig = row.ItemArray[7].ToString();

                if (pos.Contains("PCB"))
                {
                    Componentes nc = new Componentes(panel, pos, desc, asig);
                    pcb.Add(nc);
                }
            }

            foreach (Componentes comp in pcb)
            {
                combo.Items.Add(comp.panel);
            }*/

            return true;
        }

        public static DataTable getInfo(string modelo,string lote)
        {
            string url = PATH_LISTAS + @"\" + modelo + @"\" + lote + ".txt";
            DataTable dt = readLote(url);            
            return dt;
        }

        public static List<string> getPCB(DataTable dt) 
        {
            List<string> pcb = new List<string>(); 

            foreach (DataRow row in dt.Rows)
            {
                string logop = row.ItemArray[4].ToString();

                if (!pcb.Contains(logop) && !logop.Equals(""))
                {
                    pcb.Add(logop);
                }
            }
            return pcb;
        }

        public static DataTable readLote(string file)
        {
            DataTable dt = new DataTable(); // Creo una Datatable nueva.

            try
            {
                StreamReader reader = new StreamReader(file);
                string contenido = reader.ReadToEnd();
                reader.Close();

                string[] lineas = contenido.Split('\n'); // Separo las lineas por filas.

                bool first = true;
                foreach (string linea in lineas)
                {
                    string[] rows = linea.Split(LOTE_SEPARADOR);

                    if (rows.Length > 1) // Me aseguro que las filas contengan mas de una columna.
                    {
                        if (first) // Si es la primer fila, la ingreso como HEADERs
                        {
                            foreach (string row in rows)
                            {
                                dt.Columns.Add(row);
                            }
                            first = false;
                        }
                        else // El resto es una fila de la tabla.
                        { 
                            dt.Rows.Add(rows); 
                        }
                    }
                }
                return dt;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return dt;
            }
        }



        // Buscar igualdad entre un string y el otro
        public static bool findIgual(string donde, string buscar)
        {
            if (donde.ToUpper().Equals(buscar.ToUpper())) { return true; } else { return false; }
        }
        // Buscar si el string contiene la clave a buscar
        public static bool findContiene(string donde, string buscar)
        {
            if (donde.ToUpper().Contains(buscar.ToUpper())) { return true; } else { return false; }
        }
        
    }

    

    // CLASE COMPONENTES
    public class Componentes
    {
        public string panel;
        public string componente;
        public string descripcion;
        public string asignacion;

        public Componentes(string panel, string componente, string descripcion, string asignacion)
        {
            this.panel = panel;
            this.componente = componente;
            this.descripcion = descripcion;
            this.asignacion = asignacion;
        }
    }

    // CLASE COMBO
    public class Combo
    {
           public string Nombre;
           public string Valor;

           public Combo(string Name, string Value)
           {
               this.Nombre = Name;
               this.Valor = Value;
           }

           public override string ToString()
           {
               return this.Nombre;
           }
    }
}