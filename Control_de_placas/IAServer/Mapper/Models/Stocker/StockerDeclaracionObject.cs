using Newtonsoft.Json;

namespace Control_de_placas.IAServer.Mapper.Models
{
    public class StockerDeclaracionObject
    {
        [JsonProperty("declarado")]
        public bool declarado { get; set; }

        [JsonProperty("parcial")]
        public bool parcial { get; set; }

        [JsonProperty("pendiente")]
        public bool pendiente { get; set; }

        [JsonProperty("error")]
        public bool error { get; set; }

        [JsonProperty("declarado_total")]
        public int declarado_total { get; set; }

        [JsonProperty("parcial_total")]
        public int parcial_total { get; set; }

        [JsonProperty("pendiente_total")]
        public int pendiente_total { get; set; }

        [JsonProperty("error_total")]
        public int error_total { get; set; }
     }
}
