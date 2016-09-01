using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Control_de_placas
{
    class Consulta
    {      
        static public string Principal(string filtros) {
            string sql = @"
SELECT

d.id
,d.op
,d.stocker
,d.semielaborado
,d.modelo
,d.lote
,d.placa
,d.cantidad
,smt.qty as total

,(
    SELECT SUM(cantidad) as salidas
    FROM datos
    WHERE
        modelo = d.modelo
    and lote = d.lote
    and placa = d.placa
    and id_sector = d.id_sector
    and op = d.op
    GROUP BY modelo,lote,placa,id_sector, op
) AS salidas

,(
    SELECT ( SUM(cantidad) - smt.qty) as restantes
    FROM datos
    WHERE
        modelo = d.modelo
    and lote = d.lote
    and placa = d.placa
    and id_sector = d.id_sector
    and op = d.op
    GROUP BY modelo,lote,placa,id_sector, op
) as restantes

,(
    SELECT turno
    FROM turno
    where 
    id = d.id_turno
) as turno

,(
    SELECT SUM(cantidad) as turno
    FROM datos
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
,d.ebs

,(
   SELECT sector FROM sector
   WHERE
   id = id_destino
) as destino

,(
    SELECT 
    (
        SELECT operador FROM operadores
        WHERE
        id = id_operador
    ) as operador
    FROM recepcion
    WHERE
    recepcion.id_dato = d.id
    GROUP BY id_dato
) as recepcion_operador

,(
    SELECT 
    flag
    FROM recepcion
    WHERE
    recepcion.id_dato = d.id
    GROUP BY id_dato
) as recepcion_flag

,(
    SELECT 
    DATE_FORMAT(fecha,'%d/%m/%Y %H:%i') as fecha
    FROM recepcion
    WHERE
    recepcion.id_dato = d.id
    GROUP BY id_dato
) as recepcion_fecha

,
TIME_FORMAT(
TIMEDIFF(
(
    SELECT 
    fecha
    FROM recepcion
    WHERE
    recepcion.id_dato = d.id
    GROUP BY id_dato
)
,CONCAT(fecha,' ',	hora))
,'%H:%i') as transaccion


FROM 
datos d

left join (
    select op,qty
    from smtdatabase.orden_trabajo
) as smt
on smt.op = d.op

";
            sql = sql + filtros;
            return sql;
        }
    }
}
