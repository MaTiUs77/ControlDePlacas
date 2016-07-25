using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Net;
using System.Diagnostics;
using System.Xml;
using System.Collections.Specialized;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Data;

namespace Control_de_placas
{
    class Util
    {
        public static XDocument LoadXMLFromUrl(string url)
        {
            byte[] data;
            using (WebClient webClient = new WebClient())
                data = webClient.DownloadData(url);

            string str = Encoding.GetEncoding("Windows-1252").GetString(data);
            XDocument xd = XDocument.Parse(str);
            return xd;
        }

        public static bool NetUse(string ip_host, string user, string pass)
        {
            bool executed = false;
            string cmd = @"/C net use " + ip_host + " " + pass + " /user:" + user;

            ProcessStartInfo startInfo = new ProcessStartInfo("cmd", cmd);
            Process process = new Process();

            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            startInfo.CreateNoWindow = false; //nowindow
            startInfo.UseShellExecute = true; //use shell
            process = Process.Start(startInfo);
            process.WaitForExit(5000); //give it some time to finish
            process.Close();
            return executed;
        }

        // Guarda valores de custom tags en App.config 
        public static void AppConfigSave(string tag, string key, string value)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            xmlDoc.SelectSingleNode("//" + tag + "/add[@key='" + key + "']").Attributes["value"].Value = value;
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            ConfigurationManager.RefreshSection(tag);
        }

        public static string AppConfigValue(string tag, string key)
        {
            NameValueCollection vtw = ConfigurationManager.GetSection(tag) as NameValueCollection;
            string valor = vtw[key];
            return valor;
        }

        public static string AppSettingValue(string key)
        {
            string valor = ConfigurationManager.AppSettings.Get(key);
            return valor;
        }

        public static void AppSettingSave(string key, string value)
        {
            ConfigurationManager.AppSettings.Set(key,value);
        }

        // Lista archivos segun filtro, ordenados por fecha de creacion
        public static IOrderedEnumerable<FileInfo> GetFiles(string filter, string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            IOrderedEnumerable<FileInfo> fold = dir.GetFiles(filter).OrderByDescending(f => f.CreationTime);
            return fold;
        }

        // Lee archivo y devuelve el contenido en un string
        public static string ReadFile(string file)
        {
            string content = "";

            if (File.Exists(file))
            {
                StreamReader reader = new StreamReader(file);
                content = reader.ReadToEnd();
                reader.Close();
            }

            return content;
        }

        // Lectura de archivo y devolucion en datatable
        public static DataTable FileToTable(string file,  char SEPARADOR = '\t', bool INDEXADO = true, string[] COLUMNAS = null )
        {
            char FILAS = '\n';

            DataTable dt = new DataTable(); 
//            try
//            {
                string content = ReadFile(file);
                string[] lineas = content.Split(FILAS); // Separo las lineas por filas.

                // Primer columna como header?
                bool first = true;
                bool customHeaderDone = false;

                bool customHeader = false;
                if (COLUMNAS !=null && (COLUMNAS.Length > 0))
                {
                    customHeader = true;
                }

                foreach (string linea in lineas)
                {
                    string[] rows = linea.Split(SEPARADOR);

                    if (rows.Length > 1) // Me aseguro que las filas contengan mas de una columna.
                    {
                        if (first && !customHeader) // Si es la primer fila, y no defino columnas por defecto, ingreso la linea como columna.
                        {
                            int j = 0;
                            foreach (string row in rows)
                            {
                                if (INDEXADO) // Puedo asignar columnas con su respectivo INDEX.
                                {
                                    dt.Columns.Add(j.ToString());
                                }
                                else
                                {
                                    if (dt.Columns.Contains(row.ToLower()))
                                    {
                                        dt.Columns.Add(j + "_" + row.ToLower());
                                    }
                                    else
                                    {
                                        dt.Columns.Add(row.ToLower());
                                    }
                                }
                                j++;
                            }
                            first = false;
                        }
                        else
                        {
                            if (customHeader)
                            {
                                if (!customHeaderDone) // Si existen columnas personalizadas, y estas no se han seteado
                                {
                                    for (int i = 0; i < COLUMNAS.Length; i++) // Cargo columnas personalizadas.
                                    {
                                        dt.Columns.Add(COLUMNAS[i].ToString());
                                    }
                                    customHeaderDone = true;
                                }
                            }
                            dt.Rows.Add(rows); // Agrego filas.
                        }
                    }
                }
 //           }
//            catch (Exception e)
//            {
                //return dt;
//            }

            return dt;
        }

        // Obtiene una linea especifica del contenido de un archivo
        public static string GetLine(string fileContent, int line)
        {
            string return_line = "";
            string[] lines = fileContent.Split('\n');
            return_line = lines[line].Replace('\r', ' ');
            return return_line;
        }

        public static IOrderedEnumerable<DirectoryInfo> GetFolders(string filter, string fromUrl)
        {
            DirectoryInfo dir = new DirectoryInfo(fromUrl);
            IOrderedEnumerable<DirectoryInfo> fold = dir.GetDirectories(filter).OrderByDescending(f => f.CreationTime);
            return fold;
        }

        // Elimina un archivo
        public static bool DeleteFile(string archivo)
        {
            bool del = false;
            try
            {
                File.Delete(archivo);
                del = true;
            }
            catch (IOException)
            {
                del = false;
            }
            return del;
        }

        public static string GetMd5Sum(string str)
        {
            Encoder enc = System.Text.Encoding.Unicode.GetEncoder();

            byte[] unicodeText = new byte[str.Length * 2];
            enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(unicodeText);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
