using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Control_de_placas
{
    class Service
    {
        public static IEnumerable<XElement> Get(string function)
        {
            string feed = Util.AppSettingValue("service") + function + "?xml";

            XDocument xml = Util.LoadXMLFromUrl(feed);
            return xml.Descendants("service");
        }
        public static string ReadTag(string tag, IEnumerable<XElement> root)
        {
            string value = null;
            IEnumerable<XElement> elements = root.Elements(tag);
            if (elements.Count() > 0)
            {
                value = elements.First().Value.ToString();
            }
            return value;
        }
    
    }
}
