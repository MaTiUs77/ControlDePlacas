using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Control_de_placas
{
    public partial class formEstadistica : Form
    {
        public formEstadistica()
        {
            InitializeComponent();
        }

        private DataTable ModeloStat(string modelo,string lote) {
            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
SELECT
d.modelo,
d.lote,
d.placa,
t.salidas,
l.total,
(t.salidas - l.total) as restantes

FROM datos d

inner  JOIN (
SELECT modelo, lote,placa, SUM(cantidad) as salidas
FROM datos
GROUP BY modelo,lote,placa
) AS t
on d.modelo = t.modelo and d.lote = t.lote and d.placa = t.placa

left join (
select id as id_lote,modelo, lote, total
from lotes
) as l
on d.modelo = l.modelo and d.lote = l.lote

where d.modelo = '"+modelo+"' and d.lote = '"+lote+"' group by d.placa");
    return dt;
        }

        private void formEstadistica_Load(object sender, EventArgs e)
        {/*
            DataTable dt = new DataTable("T");

            dt.Columns.Add("Panel", typeof(string));
            dt.Columns.Add("Salidas", typeof(Int32));
            dt.Columns.Add("Restantes", typeof(Int32));
            dt.Columns.Add("Exceso", typeof(Int32));
            dt.Rows.Add("POW", 2000, null, null);
            dt.Rows.Add("SIR", 2000, null, 100);
            dt.Rows.Add("DAM", 900, 1100, null);
            dt.Rows.Add("KEY", 550, 1450, null);
            dt.Rows.Add("COM", 2000, null, 32);
            */

            stats("32EX655", "L102");
        }

        private void stats(string modelo,string lot)
        {
            DataTable md = ModeloStat(modelo, lot);
            DataView firstView = new DataView(md);

            chart1.Titles.Clear();
            chart1.Titles.Add(new Title { Text = modelo + "- " + lot + "(" + md.Rows[0].ItemArray[4] + ")", Font = new Font("Calibri", 15, FontStyle.Bold) });

            chart1.Palette = ChartColorPalette.None;
            chart1.PaletteCustomColors = new Color[] { 
                System.Drawing.ColorTranslator.FromHtml("#29D419"), 
                System.Drawing.ColorTranslator.FromHtml("#DAF5D7"), 
                System.Drawing.ColorTranslator.FromHtml("#DB2A2A") 
            };

            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea());

            ChartArea ch = chart1.ChartAreas[0];

            ch.AxisX.MajorGrid.Enabled = false;
            ch.AxisX.MinorGrid.Enabled = false;
            ch.AxisX.IsMarginVisible = false;
            ch.AxisX.LabelStyle.Font = new Font("Calibri", 8);

            ch.AxisY.MajorGrid.LineColor = Color.Silver;
            ch.AxisY.MinorGrid.Enabled = false;
            ch.AxisY.IsMarginVisible = false;
            ch.AxisY.MajorTickMark.Enabled = false;
            ch.AxisY.LabelStyle.Enabled = false;
            ch.Area3DStyle.Enable3D = false;

            chart1.Series.Clear();

            chart1.Series.Add(new Series { Name = "Salidas", ChartType = SeriesChartType.Column });
            chart1.Series.Add(new Series { Name = "Exceso/Restantes", ChartType = SeriesChartType.Column });
            chart1.Series.Add(new Series { Name = "Total del Lote", ChartType = SeriesChartType.Line, BorderWidth = 2 });


            Series salidas = chart1.Series[0];
            Series restantes = chart1.Series[1];
            Series lote = chart1.Series[2];

            salidas.Points.DataBindXY(firstView, "placa", firstView, "salidas");
            restantes.Points.DataBindXY(firstView, "placa", firstView, "restantes");
            lote.Points.DataBindXY(firstView, "placa", firstView, "total");

//            salidas.IsValueShownAsLabel = true;
            restantes.IsValueShownAsLabel = true;
//            lote.IsValueShownAsLabel = true;


            for (int i = 0; i < salidas.Points.Count; i++)
            {
                salidas.Points[i].AxisLabel = salidas.Points[i].AxisLabel+ "\n" + salidas.Points[i].YValues.First().ToString();
            }
//            salidas.Points.ToList().ForEach(x => x.AxisLabel = string.Format("{0}\r\n{1:#,#}", x.AxisLabel, exceso.Points[4].YValues.First()));

//            salidas.LabelBackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            restantes.LabelBackColor = System.Drawing.ColorTranslator.FromHtml("#0000FF");
            restantes.LabelForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
//            exceso.LabelBackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

//            area.AxisY.Maximum = 1800;

/*            DataPoint maxValuePoint = ser.Points.FindMaxByValue();
            maxValuePoint.Color = System.Drawing.ColorTranslator.FromHtml("#00FF00");
            */
/*            foreach (DataPoint dataPoint in ser.Points)
            {
                if (dataPoint.GetValueByName("Y") > lote)
                {
                    dataPoint.Color = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                } else if (dataPoint.GetValueByName("Y") == 1800)
                {
                    dataPoint.Color = System.Drawing.ColorTranslator.FromHtml("#00FF00");
                }
            } */

 //           chart1.ChartAreas[0].AxisY.Maximum = 
            
//            ser.Points[2].Color = System.Drawing.ColorTranslator.FromHtml("#FF0000");
//            ser.Points[0].Color = System.Drawing.ColorTranslator.FromHtml("#00FF00");
 //           ser.Points[0].AxisLabel = ser.Points[0].AxisLabel + "\n" + "100%";

/*            Series series2 = chart1.Series.Add("Lote: 1800");
            series2.ChartType = SeriesChartType.Spline;
            series2.BorderWidth = 2;

            int j = 0;
            Random rnd = new Random();
            int MaxPoints = 4;
            for (int i = 0; i < MaxPoints; i++)
            {
                series2.Points.Add(1800);
            }
            series2.Color = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            */
            /*
            area.AxisY.Title = "PANELES SALIENTES";
            area.AxisY.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
            area.AxisX.IsMarginVisible = false;
            area.AxisY.IsMarginVisible = false;
            */

/*            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
*/        }

        /*
        void ShowItemQuota(List<ItemQuotaSeries> series)
        {
            var _MaxLength = 15;
            series.Where(x => x.Name.Length > _MaxLength).ToList().ForEach(x => x.Name = x.Name.Substring(0, _MaxLength) + "...");

            chart1.Palette = ChartColorPalette.None;
            chart1.PaletteCustomColors = new Color[] { Color.Red, Color.Green };
            chart1.DataSource = series;

            chart1.Titles.Clear();
            chart1.Titles.Add(new Title { Text = "Item Quota", Font = new Font("Calibri", 15, FontStyle.Bold) });

            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea());
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Calibri", 8);
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.IsMarginVisible = false;
            chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart1.ChartAreas[0].Area3DStyle.Enable3D = false;

            chart1.Series.Clear();

            chart1.Series.Add(new Series { ChartType = SeriesChartType.StackedBar });
            chart1.Series.Add(new Series { ChartType = SeriesChartType.StackedBar });

            chart1.Series[0].Points.DataBindXY(series, "Name", series, "Used");
            chart1.Series[0].Points.ToList().ForEach(x => x.ToolTip = string.Format("{0}\r\nUsed: {1:#,#}MB", x.AxisLabel, x.YValues.First()));
            chart1.Series[0].BorderWidth = 3;
            chart1.Series[0].ShadowColor = System.Drawing.Color.Gray;
            chart1.Series[0].ShadowOffset = 2;

            chart1.Series[1].Points.DataBindXY(series, "Name", series, "Unused");
            chart1.Series[1].Points.ToList().ForEach(x => x.ToolTip = string.Format("{0}\r\nUnused: {1:#,#}MB", x.AxisLabel, x.YValues.First()));
            chart1.Series[1].BorderWidth = 3;
            chart1.Series[1].ShadowColor = System.Drawing.Color.Gray;
            chart1.Series[1].ShadowOffset = 2;

        }*/
    }
}
