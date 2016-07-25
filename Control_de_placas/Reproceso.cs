using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace Control_de_placas
{
    class Reproceso
    {
        public static string gridId = "";
        public static int gridRow = 0;
        public static string flag = "Y";

        public string QueryPrincipal(string filtros)
        {
            string sql = @"

SELECT

d.id
,d.modelo
,d.lote
,d.placa
,d.cantidad

,(
    SELECT SUM(cantidad) as salidas
    FROM reproceso
    WHERE
        modelo = d.modelo
    and lote = d.lote
    and placa = d.placa
    GROUP BY modelo,lote,placa
) AS totalidad


,(
    SELECT turno
    FROM turno
    where 
    id = d.id_turno
) as turno

,(
    SELECT SUM(cantidad) as turno
    FROM reproceso
    WHERE
        modelo = d.modelo
    and lote = d.lote
    and placa = d.placa
    and fecha = d.fecha
    and id_turno = d.id_turno
    and id_sector =  d.id_sector
    GROUP BY modelo,lote,placa,id_sector
) as por_turno

,(
    SELECT COUNT(*) as notas
    FROM notas
    where 
        id_dato = d.id
    and flag = 'N'
    GROUP BY id_dato
) as notas

,DATE_FORMAT(d.fecha, '%d/%m/%Y') as fecha
,DATE_FORMAT(d.hora, '%H:%i') as hora

,(
   SELECT sector FROM sector
   WHERE
   id = id_destino
) as destino

,(
   SELECT sector FROM sector
   WHERE
   id = id_sector
) as solicitante

,(
    SELECT 
    DATE_FORMAT(fecha,'%d/%m/%Y %H:%i') as fecha
    FROM reproceso_recepcion
    WHERE
    reproceso_recepcion.id_reproceso = d.id
    GROUP BY id_reproceso
) as fecha_llegada

,(
    SELECT 
    DATE_FORMAT(fecha_reenvio,'%d/%m/%Y %H:%i') as fecha
    FROM reproceso_recepcion
    WHERE
    reproceso_recepcion.id_reproceso = d.id
    GROUP BY id_reproceso
) as fecha_reenvio

,(
    SELECT 
    DATE_FORMAT(fecha_confirmacion,'%d/%m/%Y %H:%i') as fecha
    FROM reproceso_recepcion
    WHERE
    reproceso_recepcion.id_reproceso = d.id
    GROUP BY id_reproceso
) as fecha_confirmacion

,(
    SELECT 
    flag
    FROM reproceso_recepcion
    WHERE
    reproceso_recepcion.id_reproceso = d.id
    GROUP BY id_reproceso
) as recepcion_flag

FROM 
reproceso d

left join (
    select id,modelo, lote, total
    from lotes
) as lotes
on d.modelo = lotes.modelo and d.lote = lotes.lote


";
            sql = sql + filtros;
            return sql;
        }
        public int? ParseToNull(string categoryId)
        {
            int id;
            return int.TryParse(categoryId, out id) ? (int?)id : null;
        }
        public void CargarMain(DataGridView grid)
        {
            grid.Rows.Clear();

            Mysql sql = new Mysql();

            DataTable dt = sql.Select(QueryPrincipal(Filtro.aplicar(Filtro.reproceso)));

            foreach (DataRow d in dt.Rows)
            {
                int? cantidad = ParseToNull(d["cantidad"].ToString());
                int? totalidad = ParseToNull(d["totalidad"].ToString());


                string recepcion = d["recepcion_flag"].ToString();
                if (recepcion == "")
                {
                    recepcion = "Pendiente";
                }

                int r = grid.Rows.Add(
                    d["id"].ToString(),
                    d["modelo"].ToString(),
                    d["lote"].ToString(),
                    d["placa"].ToString(),
                    cantidad,
                    totalidad,
                    d["fecha"].ToString(),
                    d["hora"].ToString(),
                    Global.normalizarTurno(d["turno"].ToString()) + " (" + d["por_turno"].ToString() + ")",
                    d["notas"].ToString(),
                    d["solicitante"].ToString(),
                    d["destino"].ToString(),
                    d["fecha_llegada"].ToString(),
                    d["fecha_reenvio"].ToString(),
                    d["recepcion_flag"].ToString(),
                    d["fecha_confirmacion"].ToString()
                    );

                if (!d["notas"].ToString().Equals(""))
                {
                    grid.Rows[r].Cells["r_notas"] = new DataGridViewImageCell();
                    grid.Rows[r].Cells["r_notas"].Value = Properties.Resources.notas;
                    grid.Rows[r].Cells["r_notas"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (!d["fecha_reenvio"].ToString().Equals(""))
                {
                    grid.Rows[r].Cells["r_estadorecepcion"] = new DataGridViewImageCell();
                    grid.Rows[r].Cells["r_estadorecepcion"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    if (d["fecha_confirmacion"].ToString().Equals(""))
                    {
                        grid.Rows[r].Cells["r_estadorecepcion"].Value = Properties.Resources.rec_pen;
                    }
                    else
                    {
                        grid.Rows[r].Cells["r_estadorecepcion"].Value = Recepcion.icono(d["recepcion_flag"].ToString());
                    }
                }
                else
                {
                    grid.Rows[r].Cells["r_estadorecepcion"].Value = "";
                }
            }
        }

        public DataTable RecepcionData(string id_reproceso)
        {
            Mysql sql = new Mysql();

            string query = "select fecha,fecha_reenvio,fecha_confirmacion,flag from reproceso_recepcion where id_reproceso = '" + id_reproceso + "' limit 1";

            DataTable dt = sql.Select(query);
            return dt;
        }

        public bool existeReproceso(string id_reproceso) {
            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select id from reproceso where id = '"+id_reproceso+"' limit 1");
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else {
                return false;
            }
        }
        public bool RecepcionarSolicitud(string id_reproceso)
        {
            Mysql sql = new Mysql();

            if (existeReproceso(id_reproceso))
            {
                string query = @"INSERT INTO `reproceso_recepcion` (`id_reproceso`, `id_operador`, `fecha`, `fecha_reenvio`, `fecha_confirmacion`, `flag`) VALUES 
                                                               ('" + id_reproceso + "', '" + Operador.id + "', NOW(), NULL, NULL, '');";

                bool rs = sql.Ejecutar(query);
                if (rs)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                MessageBox.Show("El codigo no existe!");
                return false;
            }
        }

        public bool AgregarSolicitud(string destino, string modelo, string lote, string placa, string cantidad)
        {
            string query = @"INSERT INTO `reproceso` (`modelo`, `lote`, `placa`, `cantidad`, `fecha`, `hora`, `id_turno`, `id_sector`, `id_destino`) VALUES 
                                                         ('" + modelo + "', '" + lote + "', '" + placa + "', " + cantidad + ", CURDATE(), CURTIME(), '" + Operador.id_turno + "', '" + Operador.id_sector + "', '" + destino + "');";

            Mysql sql = new Mysql();
            bool rs = sql.Ejecutar(query);
            if (rs)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EnviarSolicitud(string id_reproceso)
        {
           
            Mysql sql = new Mysql();
            string query = @"UPDATE `reproceso_recepcion` SET `fecha_reenvio`= NOW() WHERE `id_reproceso`='" + id_reproceso + "' limit 1;";

            DataTable dt = RecepcionData(id_reproceso);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];

                if (!r["fecha_reenvio"].ToString().Equals(""))
                {
                    MessageBox.Show("Este codigo ya fue reenviado.");
                    return false;
                }
                else
                {
                    bool rs = sql.Ejecutar(query);
                    if (rs)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public bool SetPendiente(string id_reproceso) {
            string query = @"UPDATE `reproceso_recepcion` SET `flag`= 'N', `fecha_confirmacion`= NULL WHERE `id_reproceso`='" + id_reproceso + "' limit 1;";
            bool rs;
            Mysql sql = new Mysql();

            DataTable dt = RecepcionData(id_reproceso);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];

                if (r["fecha_reenvio"].ToString().Equals(""))
                {
                    return false;
                }
                else
                {
                    rs = sql.Ejecutar(query);
                    if (rs)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public bool ConfirmarEnvio(string id_reproceso)
        {
            string query = @"UPDATE `reproceso_recepcion` SET `flag`= '"+flag+"', `fecha_confirmacion`= NOW() WHERE `id_reproceso`='" + id_reproceso + "' limit 1;";
            bool rs;
            Mysql sql = new Mysql();

            DataTable dt = RecepcionData(id_reproceso);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];

                if (r["fecha_reenvio"].ToString().Equals(""))
                {
                    return false;
                }
                else
                {
                    rs = sql.Ejecutar(query);
                    if (rs)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
    }
}
