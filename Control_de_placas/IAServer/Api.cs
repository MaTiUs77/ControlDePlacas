using Control_de_placas.Src.Config;
using Control_de_placas.Src.Service;
using System;

namespace Control_de_placas.IAServer
{
    public class Api : ServiceJson
    {
        public static string apiUrl = "";

        public Api()
        {
            if (apiUrl.Equals(""))
            {
                apiUrl = AppConfig.Read("IASERVER", "apiurl");
            }
        }

        public Exception exception { get; set; }
        public new bool hasResponse { get; set; }
    }
}
