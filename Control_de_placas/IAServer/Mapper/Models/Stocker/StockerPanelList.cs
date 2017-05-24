using Newtonsoft.Json;
using System.Collections.Generic;

namespace Control_de_placas.IAServer.Mapper.Models
{
    public class StockerPanelList
    {
        [JsonProperty("panel")]
        public Panel panel { get; set; }

        [JsonProperty("declaracion")]
        public StockerDeclaracionObject declaracion { get; set; }
    }
}
