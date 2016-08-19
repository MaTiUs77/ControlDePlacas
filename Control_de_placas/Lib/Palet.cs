using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Control_de_placas
{
    public class Palet
    {
        public List<Stocker> stockerList = new List<Stocker>();
        public string modelo = "";
        public string lote = "";
        public string panel = "";
        public string op = "";
        public string barcode = "";
        public string semielaborado = "";

        public int unidades = 0;

        public bool started = false;

        public void Init(Stocker stocker) {
            // Cargo por primera vez
            modelo = stocker.service.smt.modelo;
            lote = stocker.service.smt.lote;
            panel = stocker.service.smt.panel;

            op = stocker.service.stocker.op;
            barcode = stocker.service.stocker.barcode;
            semielaborado = stocker.service.stocker.semielaborado;

            started = true;
        }

        public void AddToList(Stocker stocker) 
        {
            stockerList.Add(stocker);
        }

        public int? SumarUnidades() {
            int? total = stockerList.AsEnumerable().Sum(s => s.service.stocker.unidades);
            return total;
        }

        public int CountConfirm()
        {
            int total = stockerList.AsEnumerable().Count(s => s.confirm == true);
            return total;
        }

        public int CountAll()
        {
            int total = stockerList.AsEnumerable().Count();
            return total;
        }

        public bool OnList(Stocker currStocker)
        {
            IEnumerable<Stocker> result = stockerList.Where(s => s.service.stocker.barcode== currStocker.service.stocker.barcode);
            if (result.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void enviarAll()
        {
            foreach (Stocker stocker in stockerList)
            {
                Stocker.enviado(stocker.service.stocker.barcode);
            }
        }
    }
}
