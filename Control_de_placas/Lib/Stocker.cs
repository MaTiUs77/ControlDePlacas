using System.Collections.Generic;
using System.Xml.Linq;
using IAServerServiceDll;
using IAServerServiceDll.Mapper;
using System;
using System.Windows.Forms;

namespace Control_de_placas
{
    public class Stocker
    {
        public int row;
        public bool confirm = false;
        public bool isDeclared = false;
        public string exception;

        public StockerMapper info;
        public StockerDeclaredMapper declared;

        public StockerMapper getInfo(string stocker_barcode)
        {
            try
            {
                IAServerService ias = new IAServerService();
                info = ias.GetStockerInfo(stocker_barcode);
                if(ias.error!=null)
                {
                    throw ias.error;
                } else
                {
                    return info;
                }
            } catch(Exception ex)
            {
                exception = ex.Message;
            }

            return info;
        }

        public StockerDeclaredMapper getDeclaredInfo()
        {
            try
            {
                IAServerService ias = new IAServerService();
                declared = ias.GetStockerDeclaredInfo(info.stocker.barcode);
                if (ias.error != null)
                {
                    throw ias.error;
                }
                else
                {
                    return declared;
                }
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            return declared;
        }

        public static StockerMapper enviado(string stocker_barcode)
        {
            IAServerService ias = new IAServerService();
            StockerMapper service = new StockerMapper();

            try
            {
                service = ias.SetStockerRoute(stocker_barcode, "controldeplacas");
                if (ias.error != null)
                {
                    throw ias.error;
                }
                else
                {
                    return service;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al trazabilizar stocker: "+ex.Message);
                //exception = ex.Message;
            }

            return service;
        }
    }
}
