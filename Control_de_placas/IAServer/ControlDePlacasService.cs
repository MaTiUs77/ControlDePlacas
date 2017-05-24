using Control_de_placas.IAServer.Mapper;
using Newtonsoft.Json;
using System;

namespace Control_de_placas.IAServer
{
    public class ControlDePlacasService : Api
    {
        public InfoStockerMapper info;
        public VerifyStockerMapper verify;
        public SetRouteMapper route;
        public OPInfoMapper opinfo;

        public VerifyStockerMapper VerifyStockerApi(string stkbarcode)
        {
            verify = new VerifyStockerMapper();
            hasResponse = false;
            exception = null;

            try
            {
                string path = string.Format("{0}/controldeplacas/verifystocker/{1}", apiUrl, stkbarcode);

                string jsonData = Consume(path);
                hasResponse = true;
                verify = JsonConvert.DeserializeObject<VerifyStockerMapper>(jsonData);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return verify;
        }

        public InfoStockerMapper InfoStockerApi(string stkbarcode)
        {
            info = new InfoStockerMapper();
            hasResponse = false;
            exception = null;

            try
            {
                string path = string.Format("{0}/controldeplacas/infostocker/{1}", apiUrl, stkbarcode);

                string jsonData = Consume(path);
                hasResponse = true;
                info = JsonConvert.DeserializeObject<InfoStockerMapper>(jsonData);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return info;
        }

        public SetRouteMapper SetRouteApi(string stkbarcode)
        {
            route = new SetRouteMapper();
            hasResponse = false;
            exception = null;

            try
            {
                string path = string.Format("{0}/controldeplacas/setroute/{1}", apiUrl, stkbarcode);

                string jsonData = Consume(path);
                hasResponse = true;
                route = JsonConvert.DeserializeObject<SetRouteMapper>(jsonData);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return route;
        }

        public OPInfoMapper OPInfoApi(string op)
        {
            opinfo = new OPInfoMapper();
            hasResponse = false;
            exception = null;

            try
            {
                string path = string.Format("{0}/controldeplacas/opinfo/{1}", apiUrl, op);

                string jsonData = Consume(path);
                hasResponse = true;
                opinfo = JsonConvert.DeserializeObject<OPInfoMapper>(jsonData);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return opinfo;
        }

    }
}