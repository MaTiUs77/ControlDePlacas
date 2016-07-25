using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control_de_placas
{
    public partial class formScrap : Form
    {
        public formScrap()
        {
            InitializeComponent();
        }

        private void formScrap_Load(object sender, EventArgs e)
        {
            Filtro n = new Filtro();
            loadScrap(n);
        }
        private string Consulta() {
           string sql = @"SELECT

d.id
,d.modelo
,d.lote
,d.placa
,d.cantidad

,(
    SELECT SUM(cantidad) as salidas
    FROM scrap
    WHERE
        modelo = d.modelo
    and lote = d.lote
    and placa = d.placa
    GROUP BY modelo,lote,placa
) AS total

,(
    SELECT turno
    FROM turno
    where 
    id = d.id_turno
) as turno

,(
    SELECT SUM(cantidad) as turno
    FROM scrap
    WHERE
        modelo = d.modelo
    and lote = d.lote
    and placa = d.placa
    and fecha = d.fecha
    and id_turno = d.id_turno
    GROUP BY modelo,lote,placa
) as por_turno

,(
    SELECT COUNT(*) as notas
    FROM notas
    where 
        id_dato = d.id
    and flag = 'S'
    GROUP BY id_dato
) as notas

,DATE_FORMAT(d.fecha, '%d/%m/%Y') as fecha
,DATE_FORMAT(d.hora, '%H:%i') as hora

FROM 
scrap d

";
            return sql;
        }

        private void loadScrap(Filtro f) {

            gridScrap.Rows.Clear();

            Mysql sql = new Mysql();

            string query = Consulta() + Filtro.aplicar(f);
            
            DataTable dt = sql.Select(query);

            foreach (DataRow r in dt.Rows)
            {
                string id = r["id"].ToString();
                string modelo = r["modelo"].ToString();
                string lote = r["lote"].ToString();
                string placa = r["placa"].ToString();
                string cantidad = r["cantidad"].ToString();
                string total = r["total"].ToString();
                string fecha = r["fecha"].ToString();
                string hora = r["hora"].ToString();
                string turno = r["turno"].ToString() + "(" + r["por_turno"].ToString()  + ")";

                gridScrap.Rows.Add(
                    id,
                    modelo,
                    lote,
                    placa,
                    cantidad,
                    total,
                    turno,
                    fecha,
                    hora
                );
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formFiltro ff = new formFiltro(this);
            ff.Show();
        }

        // Aplicar filtro
        public void aplicarFiltro(Filtro filtro)
        {        
            loadScrap(filtro);
        }
    }
}
