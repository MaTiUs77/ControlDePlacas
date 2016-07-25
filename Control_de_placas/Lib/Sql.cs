using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control_de_placas
{
    class Sql
    {
        // Inserta en la DB una salida de stocker
        public static bool InsertarDato(string modelo, string lote, string placa, int cantidad, int id_destino, string op, string stocker_barcode, string semielaborado)
        {
            Mysql sql = new Mysql();
            bool rs = sql.Ejecutar(@"INSERT INTO `datos` (`id`, `modelo`, `lote`, `placa`, `cantidad`, `fecha`, `hora`, `ebs`, `id_turno`, `id_sector`, `id_destino`, `op`, `stocker`, `semielaborado`) VALUES 
                                                         (NULL, '" + modelo + "', '" + lote + "', '" + placa + "', '" + cantidad + "', CURDATE(), CURTIME(), '0', '" + Operador.id_turno + "', '" + Operador.id_servidor + "', '" + id_destino + "', '" + op + "', '" + stocker_barcode + "', '" + semielaborado + "');");
            if (!rs)
            {
                MessageBox.Show("InsertarDato(): Error al insertar en tabla.");
            }
            return rs;
        }
    }
}
