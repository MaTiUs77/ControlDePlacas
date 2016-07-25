using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace Control_de_placas
{
    class Recepcion
    {
        public string id = "";
        public string id_dato = "";
        public string flag = "";
        public string nflag = "";
        public string fecha = "";

        public string id_destino = "";

        public bool recepcionar = false;
        public bool pendiente = false;
        public bool id_dato_error = false;
        public bool recepcionado = false;
        public bool actualizar = false;

        public string curr_flag = "";
        public string curr_fecha = "";

        public DataTable Info() {
            string query = @"
SELECT 

 s.id as id_dato
,s.id_destino
,r.id
,r.fecha
,r.flag

FROM datos s

left join (
    select id,flag,id_dato,fecha from recepcion 
) as r
on r.id_dato = s.id
where s.id = '" + id_dato + "' limit 1";

            Mysql sql = new Mysql();
            DataTable dt = sql.Select(query);
            if (dt.Rows.Count > 0)
            {
                // DATO RECEPCIONADO
                DataRow r = dt.Rows[0];
                id = r["id"].ToString();
                id_dato = r["id_dato"].ToString();
                fecha = r["fecha"].ToString();
                id_destino = r["id_destino"].ToString();
                flag = r["flag"].ToString();

                if (flag.Equals(""))
                {
                    pendiente = true;
                }
            }
            else
            {
                id_dato_error = true;
            }
                
            return dt;
        }

        public void Verificar()
        {
            DataTable dt = Info();

            if (id_dato_error)
            {
                // Verificar estados de flag.
                MessageBox.Show("El codigo " + id_dato + " no existe.", "ATENCION",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                // DATO EXISTENTE 
                if (Operador.acceso.Equals("R"))
                {
                    if (pendiente)
                    {
                        /*
                         * Si el envio le corresponde al receptor, o si el destino no fue definido, puedo recepcionar.
                         */
                        if (id_destino == Operador.id_sector || id_destino == "0")
                        {
                            recepcionar = true;
                        }
                        else
                        {
                            recepcionar = false;
                            MessageBox.Show(
                                        "No puede recepcionar un envio destinado a otro sector",
                                        "ATENCION",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation
                                        );
                        }
                    }
                    else
                    {
                        recepcionado = true;
                    }
                }
                else
                {
                    MessageBox.Show("No esta habilitado para realizar recepciones.", "ATENCION",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                }
            }
        }

        public bool Agregar()
        {
            bool rt = false;
            Verificar();

            if (recepcionar)
            {
                rt = Insertar();
            }
            else
            {
                if(recepcionado){
                    if (actualizar)
                    {
                        Update();
                    }
                    else
                    {
                        MessageBox.Show(
                          "Ya se realizo la recepcion de este codigo anteriormente.",
                          "ATENCION",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Exclamation
                          );
                    }
                    rt = true;
                }
            }

            Estatus();


            return rt;
        }

        public bool Insertar() {
            bool rt = false;
            string query = "INSERT INTO `recepcion` (`id`,`id_dato`, `id_operador`, `flag`, `fecha`) VALUES (NULL," + id_dato + ", " + Operador.id + ", '" + nflag + "', NOW());";

            Mysql sql = new Mysql();
            bool rs = sql.Ejecutar(query);

            if (rs)
            {
                rt = true;
            }
            else
            {
                //                    MessageBox.Show("Ocurrio un error al realizar la accion, intente mas tarde.");
                rt = false;
            }
            return rt;
        }

        public bool Update()
        {
            bool rt = false;
            string query = "UPDATE `recepcion` SET `id_operador`='"+Operador.id+"', `flag`='"+nflag+"' WHERE `id`='"+id+"';";

            Mysql sql = new Mysql();
            bool rs = sql.Ejecutar(query);

            if (rs)
            {
                rt = true;
            }
            else
            {
                rt = false;
            }
            return rt;
        }

        public bool Eliminar() {
            Mysql sql = new Mysql();
            bool rs = sql.Ejecutar("DELETE FROM `recepcion` WHERE `id_dato`='"+id_dato+"' limit 1;");
            if (rs)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Estatus()
        {
            string query = @" select DATE_FORMAT(fecha,'%d/%m/%Y %H:%i') as fecha,flag   FROM recepcion  where id_dato = '" + id_dato + "' limit 1";

            Mysql sql = new Mysql();
            DataTable dt = sql.Select(query);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                curr_fecha = r["fecha"].ToString();
                curr_flag = r["flag"].ToString();
            }

        }
        public static Bitmap icono(string flag)
        {
            Bitmap recep = new Bitmap(1, 1);
            switch (flag)
            {
                default:
                    recep = Properties.Resources.rec_pen;
                    break;
                case "Y":
                    recep = Properties.Resources.rec_si;
                    break;
                case "N":
                    recep = Properties.Resources.rec_no;
                    break;
            }
            return recep;
        }
    }
}