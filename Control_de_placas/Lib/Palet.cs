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
            modelo = stocker.modelo;
            lote = stocker.lote;
            panel = stocker.panel;
            op = stocker.op;
            barcode = stocker.barcode;
            semielaborado = stocker.semielaborado;

            started = true;
        }

        public void AddToList(Stocker stocker) 
        {
            stockerList.Add(stocker);
        }

        public int SumarUnidades() {
            int total = stockerList.AsEnumerable().Sum(s => s.unidades);
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

        public bool OnList(Stocker stocker)
        {
            IEnumerable<Stocker> result = stockerList.Where(s => s.barcode == stocker.barcode);
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
                Stocker.enviado(stocker.barcode);
            }
        }
    }
}
