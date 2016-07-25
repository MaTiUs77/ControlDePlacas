using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Control_de_placas
{
    public class OP
    {
        public string error;

        public string op;

        public string semielaborado;
        public string modelo;
        public string lote;
        public string panel;

        public void getInfo(string _op)
        {
            // Get data
            IEnumerable<XElement> result = Service.Get("/infoop/" + _op);
            IEnumerable<XElement> wip = result.Descendants("wip");
            IEnumerable<XElement> smt = result.Descendants("smt");

            if(smt!=null)
            {
                op = _op.ToUpper();
                modelo = Service.ReadTag("modelo", smt);
                lote = Service.ReadTag("lote", smt);
                panel = Service.ReadTag("panel", smt);
                if(wip!=null)
                {
                    semielaborado = Service.ReadTag("codigo_producto", wip.Descendants("wip_ot"));
                }
            }
        }
    }
}
