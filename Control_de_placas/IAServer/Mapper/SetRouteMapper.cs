using Control_de_placas.IAServer.Mapper.Models;
using Newtonsoft.Json;

namespace Control_de_placas.IAServer.Mapper
{
    public class SetRouteMapper
    {
        [JsonProperty("linea")]
        public string linea { get; set; }

        [JsonProperty("stocker")]
        public Stocker stocker { get; set; }

        [JsonProperty("smt")]
        public Smt smt{ get; set; }

        [JsonProperty("contenido")]
        public StockerContenido contenido { get; set; }
    }
}
