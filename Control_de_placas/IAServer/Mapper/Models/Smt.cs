using Newtonsoft.Json;

namespace Control_de_placas.IAServer.Mapper.Models
{
    public class Smt
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("op")]
        public string op { get; set; }

        [JsonProperty("modelo")]
        public string modelo{ get; set; }
        
        [JsonProperty("lote")]
        public string lote { get; set; }

        [JsonProperty("panel")]
        public string panel { get; set; }

        [JsonProperty("semielaborado")]
        public string semielaborado { get; set; }

        [JsonProperty("prod_aoi")]
        public int? prod_aoi { get; set; }

        [JsonProperty("prod_man")]
        public int? prod_man { get; set; }

        [JsonProperty("qty")]
        public int? qty { get; set; }
    }
}
