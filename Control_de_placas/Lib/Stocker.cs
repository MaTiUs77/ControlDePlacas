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
        public string exception;
        public StockerDeclaredMapper service;

        public StockerDeclaredMapper getInfo(string stocker_barcode)
        {
            try
            {
                IAServerService ias = new IAServerService();
                service = ias.GetStockerDeclaredInfo(stocker_barcode);
                if(ias.error!=null)
                {
                    throw ias.error;
                } else
                {
                    return service;
                }
            } catch(Exception ex)
            {
                exception = ex.Message;
            }

            return service;
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
