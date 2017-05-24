using Newtonsoft.Json;
using System.Collections.Generic;

namespace Control_de_placas.IAServer.Mapper.Models
{
    public class StockerContenido
    {
        [JsonProperty("declaracion")]
        public StockerDeclaracionObject declaracion { get; set; }

        [JsonProperty("paneles")]
        public List<StockerPanelList> paneles { get; set; }

    }
}
