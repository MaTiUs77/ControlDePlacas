using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Control_de_placas
{
    public class Stocker
    {
        public int row;
        public bool confirm = false;

        public string error;

        public int id;
        public string barcode;
        public string aoi_barcode;
        public string op;
        public int limite;
        public int bloques;
        public int unidades;
        public int paneles;
        public int despachado;
        public int full;

        public string semielaborado;
        public string modelo;
        public string lote;
        public string panel;

        public void getInfo(string stocker_barcode)
        {
            // Get data
            IEnumerable<XElement> result = Service.Get("/stocker/info/"+stocker_barcode);
            this.error = Service.ReadTag("error", result);

            if (this.error == null)
            {
                IEnumerable<XElement> stocker = result.Descendants("stocker");
                IEnumerable<XElement> smt = result.Descendants("smt");

                // Fill data
                this.id = int.Parse(Service.ReadTag("id", stocker));
                if (id > 0)
                {
                    this.barcode = Service.ReadTag("barcode", stocker);
                    this.aoi_barcode = Service.ReadTag("aoi_barcode", stocker);
                    this.op = Service.ReadTag("op", stocker);
                    this.limite = int.Parse(Service.ReadTag("limite", stocker));
                    this.bloques = int.Parse(Service.ReadTag("bloques", stocker));
                    this.unidades = int.Parse(Service.ReadTag("unidades", stocker));
                    this.paneles = int.Parse(Service.ReadTag("paneles", stocker));
                    this.despachado = int.Parse(Service.ReadTag("despachado", stocker));
                    this.full = int.Parse(Service.ReadTag("full", stocker));
                    this.semielaborado =Service.ReadTag("semielaborado", stocker);

                    this.modelo = Service.ReadTag("modelo", smt);
                    this.lote = Service.ReadTag("lote", smt);
                    this.panel = Service.ReadTag("panel", smt);
                }
            }
        }

        public static void enviado(string stocker_barcode)
        {
            // Get data
            var result = Service.Get("/stocker/controldeplacas/" + stocker_barcode);
        }
    }
}
