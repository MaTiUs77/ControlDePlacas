using Control_de_placas.IAServer;
using Control_de_placas.IAServer.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_de_placas
{
    public class Palet
    {
        public DataGridView dataPalet;
        public TextBox detailPalet;
        public List<StockerObj> stockerList = new List<StockerObj>();
        public string modelo = "";
        public string lote = "";
        public string panel = "";
        public string op = "";
        public string barcode = "";
        public string semielaborado = "";

        public int scrap = 0;

        public int unidades = 0;

        public bool started = false;

        public void Init(ControlDePlacasService api) {
            // Cargo por primera vez
            modelo = api.info.smt.modelo;
            lote = api.info.smt.lote;
            panel = api.info.smt.panel;

            op = api.info.stocker.op;
            barcode = api.info.stocker.barcode;
            semielaborado = api.info.stocker.semielaborado;

            started = true;
        }

        public int? SumarUnidades() {
            int? total = stockerList.AsEnumerable().Sum(s => s.api.info.stocker.unidades);
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
            IEnumerable<StockerObj> result = stockerList.Where(s => s.api.info.stocker.barcode == stockerBarcode);
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
                StockerObj result = stockerList.Where(s => s.api.info.stocker.barcode == stockerBarcode).FirstOrDefault();
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
            foreach (StockerObj stk in stockerList)
            {
                stk.api.SetRouteApi(stk.api.info.stocker.barcode);
            }
        }

        public async void AddToPalet(ControlDePlacasService api)
        {
            if (!OnList(api.info.stocker.barcode))
            {
                int index = dataPalet.Rows.Add(
                    api.info.stocker.barcode,
                    api.info.stocker.unidades
                );

                StockerObj stk = new StockerObj();
                stk.api = api;

                // Agrego indice de fila a stocker.
                stk.row = index;

                stockerList.Add(stk);

                StockerResume();

                await Task.Run(() => StartVerify(stk));
            }
        }

        public void StockerResume()
        {
            StockerObj stk = stockerList.FirstOrDefault();
            if (stk != null)
            {
                detailPalet.Text = string.Concat(
                stk.api.info.smt.op,
                    Environment.NewLine,
                "Modelo: ",
                stk.api.info.smt.modelo,
                    Environment.NewLine,
                "Lote: ",
                stk.api.info.smt.lote,
                    Environment.NewLine,
                "Panel: ",
                stk.api.info.smt.panel,
                    Environment.NewLine,
                "Unidades: ",
                SumarUnidades());
            } else
            {
                detailPalet.Text = "";
            }
        }

        private void StartVerify(StockerObj stk)
        {
            DataGridViewCell cell = dataPalet.Rows[stk.row].Cells["_declarado"];
            DataGridViewCellStyle style = dataPalet.Rows[stk.row].DefaultCellStyle;

            cell.Value = "Verificando...";
            stk.isDeclared = false;

            try
            {
                stk.api.VerifyStockerApi(stk.api.info.stocker.barcode);
                if (stk.api.hasResponse)
                {
                    if (stk.api.verify.error == null)
                    {
                        if (stk.api.verify.cuarentena.Count() == 0) 
                        {
                            if (stk.api.verify.contenido.declaracion.declarado)
                            {
                                style.BackColor = ColorTranslator.FromHtml("#6de9ff");
                                cell.Value = "Declarado";
                                stk.isDeclared = true;
                            }
                            else
                            {
                                style.BackColor = ColorTranslator.FromHtml("#ff6730");
                                cell.Value = "Error en declaraciones";
                                stk.isDeclared = false;
                            }
                        }
                        else
                        {
                            style.BackColor = ColorTranslator.FromHtml("#ff6730");
                            cell.Value = string.Format("Atencion! hay {0} placa(s) en cuarentena", stk.api.verify.cuarentena.Count());

                        }
                    } else
                    {
                        style.BackColor = ColorTranslator.FromHtml("#ff6730");
                        cell.Value = stk.api.verify.error;
                    }
                }
                else
                {
                    style.BackColor = ColorTranslator.FromHtml("#ff6730");
                    cell.Value = stk.api.exception;
                }
            }
            catch (Exception ex)
            {
                style.BackColor = ColorTranslator.FromHtml("#ff6730");
                cell.Value = ex.Message;
            }

            dataPalet.ClearSelection();
        }
    }
}
