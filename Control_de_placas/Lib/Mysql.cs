using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace Control_de_placas
{
    class Mysql
    {
        private MySqlConnection connection;
        public static string server = "";
        public static string database = "";
        public static string user = "";
        public static string password = "";

        public Mysql()
        {
            Initialize();
        }

        private void Initialize()
        {
            string connectionString;
            connectionString = "SERVER=" + Mysql.server + ";" + "DATABASE=" + Mysql.database + ";" + "UID=" + Mysql.user + ";" + "PASSWORD=" + Mysql.password + ";";
            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 1042:
                        MessageBox.Show("MYSQL: No se pudo conectar al servidor.");
                    break;
                    case 1045:
                    MessageBox.Show("MYSQL: Usuario/Password incorrectos.");
                    break;
                    case 1044:
                    MessageBox.Show("MYSQL: Acceso denegado a la tabla.");
                    break;
                    default:
                        MessageBox.Show("MYSQL: ("+ex.Number+") "+ex.Message);
                    break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool Ejecutar(string query)
        {
            bool rs = false;
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    if (cmd.ExecuteNonQuery() > 0) { rs = true; }
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 1062:
                            MessageBox.Show("MYSQL: Ya existe el elemento, no puede haber duplicados.");
                        break;
                        default:
                            MessageBox.Show("MYSQL: (" + ex.Number + ") " + ex.Message);
                        break;
                    }
                }
                this.CloseConnection();
            }
            return rs;
        }

        public DataTable Select(string query)
        {
            DataTable rs = new DataTable();
            bool header = true;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        int total = rdr.FieldCount;

                        if (header)
                        {
                            for (int j = 0; j < total; j++)
                            {
                                string cname = rdr.GetName(j).ToString();
                                rs.Columns.Add(cname);
                            }
                            header = false;
                        }

                        object[] rows = new object[total];

                        for (int i = 0; i < total; i++)
                        {
                            rows[i] = rdr.GetValue(i).ToString();
                        }

                        rs.Rows.Add(rows);
                    }
                }
                this.CloseConnection();
            }
            return rs;
        }
    }
}