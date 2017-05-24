using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_placas.Src.Service
{
    public class ServiceJson
    {
        public bool hasResponse = false;

        public string Consume(string route)
        {
            string jsonData = WebDownload(route);
            return jsonData;
        }

        public string WebDownload(string url)
        {
            byte[] data;
            using (WebClient webClient = new WebClient())
                data = webClient.DownloadData(url);

            string str = Encoding.GetEncoding("Windows-1252").GetString(data);
            return str;
        }
    }
}
