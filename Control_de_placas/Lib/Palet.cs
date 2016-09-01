using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_de_placas
{
    public class Palet
    {
        public DataGridView dataPalet;
        public TextBox detailPalet;
        public List<Stocker> stockerList = new List<Stocker>();
        public string modelo = "";
        public string lote = "";
        public string panel = "";
        public string op = "";
        public string barcode = "";
        public string semielaborado = "";

        public int scrap = 0;

        public int unidades = 0;

        public bool started = false;

        public void Init(Stocker stocker) {
            // Cargo por primera vez
            modelo = stocker.info.smt.modelo;
            lote = stocker.info.smt.lote;
            panel = stocker.info.smt.panel;

            op = stocker.info.stocker.op;
            barcode = stocker.info.stocker.barcode;
            semielaborado = stocker.info.stocker.semielaborado;

            started = true;
        }

        public void AddToList(Stocker stocker) 
        {
            stockerList.Add(stocker);
        }

        public int? SumarUnidades() {
            int? total = stockerList.AsEnumerable().Sum(s => s.info.stocker.unidades);
            return total - scrap;
        }

        public int CountConfirm()
        {
            int total = stockerList.AsEnumerable().Count(s => s.confirm == true);
            return total;
        }

        public int CountDeclared()
        {
            int total = stockerList.AsEnumerable().Count(s => s.isDeclared == true);
            return total;
        }

        public int CountAll()
        {
            int total = stockerList.AsEnumerable().Count();
            return total;
        }

        public bool OnList(string stockerBarcode)
        {
            IEnumerable<Stocker> result = stockerList.Where(s => s.info.stocker.barcode== stockerBarcode);
            if (result.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void RemoveFromList(string stockerBarcode)
        {
            if(stockerList.Count() > 0)
            {
                Stocker result = stockerList.Where(s => s.info.stocker.barcode == stockerBarcode).FirstOrDefault();
                if (result != null)
                {
                    dataPalet.Rows[result.row].Visible = false;
                    stockerList.Remove(result);
                    StockerResume();
                }
            }
        }

        public void enviarAll()
        {
            foreach (Stocker stocker in stockerList)
            {
                Stocker.enviado(stocker.info.stocker.barcode);
            }
        }

        public async void AddToPalet(Stocker stk)
        {
            if (!OnList(stk.info.stocker.barcode))
            {
                int index = dataPalet.Rows.Add(
                    stk.info.stocker.barcode,
                    stk.info.stocker.unidades
                );

                // Agrego indice de fila a stocker.
                stk.row = index;

                AddToList(stk);

                StockerResume();

                await Task.Run(() => StartVerify(stk));
            }
        }

        public void StockerResume()
        {
            Stocker stk = stockerList.FirstOrDefault();
            if (stk != null)
            {
                detailPalet.Text = string.Concat(
                stk.info.smt.op,
                    Environment.NewLine,
                "Modelo: ",
                stk.info.smt.modelo,
                    Environment.NewLine,
                "Lote: ",
                stk.info.smt.lote,
                    Environment.NewLine,
                "Panel: ",
                stk.info.smt.panel,
                    Environment.NewLine,
                "Unidades: ",
                SumarUnidades());
            } else
            {
                detailPalet.Text = "";
            }
        }

        private void StartVerify(Stocker stocker)
        {
            DataGridViewCell cell = dataPalet.Rows[stocker.row].Cells["_declarado"];
            DataGridViewCellStyle style = dataPalet.Rows[stocker.row].DefaultCellStyle;

            cell.Value = "Verificando...";

            try
            {
                stocker.getDeclaredInfo();
                if (stocker.exception == null)
                {
                    if (stocker.info.stocker.error == null)
                    {
                        if (stocker.declared.detalle.stocker_declarado)
                        {
                            style.BackColor = ColorTranslator.FromHtml("#6de9ff");
                            cell.Value = "Declarado";
                            stocker.isDeclared = true;
                        }
                        else
                        {
                            style.BackColor = ColorTranslator.FromHtml("#ff6730");
                            cell.Value = "Error en declaraciones";
                        }
                    }
                }
                else
                {
                    style.BackColor = ColorTranslator.FromHtml("#ff6730");
                    cell.Value = stocker.exception;
                }
            }
            catch (Exception ex)
            {
                dataPalet.Rows[stocker.row].Cells["_declarado"].Value = ex.Message;
                style.BackColor = ColorTranslator.FromHtml("#ff6730");
                cell.Value = ex.Message;
            }

            dataPalet.ClearSelection();
        }
    }
}
