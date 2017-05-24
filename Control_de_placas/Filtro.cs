using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Control_de_placas
{
    public class Filtro
    {
        public static Filtro main = new Filtro();
        public static Filtro reproceso = new Filtro();

        public string id = "";
        public string ebs = "";
        public string op = "";
        public string modelo = "";
        public string lote = "";
        public string placa = "";
        public string desde = "";
        public string hasta = "";
        public string id_destino = "";
        public string id_solicitante = "";
        public string recepcion = "A";

        public string id_servidor = "";

        public static string aplicar(Filtro f)
        {
            string sql = "";
            List<string> sqlString = new List<string>();

            if (!f.modelo.Equals(""))
            {
                sqlString.Add(" d.modelo = '" + f.modelo + "' ");
            }

            if (!f.lote.Equals(""))
            {
                sqlString.Add(" d.lote = '" + f.lote + "' ");
            }

            if (!f.placa.Equals(""))
            {
                sqlString.Add(" d.placa = '" + f.placa + "' ");
            }


            if (!f.id.Equals(""))
            {
                sqlString.Add(" d.id = '" + f.id + "' ");
            }
            else
            {
                if (!f.desde.Equals("") && !f.hasta.Equals(""))
                {
                    sqlString.Add(" d.fecha >= '" + f.desde + "' and d.fecha <= '" + f.hasta + "' ");
                }
                else
                {
                    sqlString.Add(" d.fecha = CURDATE() ");
                }
            }


            if (!f.id_destino.Equals(""))
            {
                sqlString.Add(" d.id_destino = '" + f.id_destino + "' ");
            }

            if (!f.id_solicitante.Equals(""))
            {
                sqlString.Add(" d.id_sector = '" + f.id_solicitante + "' ");
            }

            if (!f.id_servidor.Equals(""))
            {
                sqlString.Add(" d.id_sector = '" + f.id_servidor + "' ");
            }

            if (!f.ebs.Equals(""))
            {
                sqlString.Add(" d.ebs= '" + f.ebs+ "' ");
            }

            if (!f.op.Equals(""))
            {
                sqlString.Add(" d.op= '" + f.op + "' ");
            }

            switch (f.recepcion)
            {
                case "R":
                    sqlString.Add(" EXISTS(select id_dato from recepcion where id_dato = d.id) ");
                break;
                case "P":
                    sqlString.Add(" NOT EXISTS(select id_dato from recepcion where id_dato = d.id) ");
                break;
            }
            

            if (sqlString.Count > 0)
            {
                sql += " where ";
                sql += string.Join(" and ", sqlString);
            }

            sql += @" 
            order by d.id desc
            ";
            return sql;
        }

        public static void limpiarMain()
        {
            Filtro.main.id = "";
            Filtro.main.modelo = "";
            Filtro.main.lote = "";
            Filtro.main.placa = "";
            Filtro.main.desde = "";
            Filtro.main.hasta = "";

            Filtro.main.id_destino = "";
            Filtro.main.recepcion = "";
            Filtro.main.op = "";
        }

        public static void limpiarReproceso()
        {
            Filtro.reproceso.id = "";
            Filtro.reproceso.modelo = "";
            Filtro.reproceso.lote = "";
            Filtro.reproceso.placa = "";
            Filtro.reproceso.desde = "";
            Filtro.reproceso.hasta = "";

            Filtro.reproceso.id_destino = "";
            Filtro.reproceso.recepcion = "";
            Filtro.reproceso.op = "";
        }
    }
}
