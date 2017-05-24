using Newtonsoft.Json;

namespace Control_de_placas.IAServer.Mapper.Models
{
    public class Stocker
    {
        [JsonProperty("error")]
        public string error { get; set; }

        [JsonProperty("code")]
        public int? code { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("barcode")]
        public string barcode { get; set; }

        [JsonProperty("aoi_barcode")]
        public string aoi_barcode { get; set; }

        [JsonProperty("op")]
        public string op { get; set; }

        [JsonProperty("semielaborado")]
        public string semielaborado { get; set; }

        [JsonProperty("limite")]
        public int? limite { get; set; }

        [JsonProperty("bloques")]
        public int? bloques { get; set; }

        [JsonProperty("paneles")]
        public int? paneles { get; set; }

        [JsonProperty("despachado")]
        public int? despachado { get; set; }

        [JsonProperty("unidades")]
        public int? unidades { get; set; }

        [JsonProperty("full")]
        public int? full { get; set; }
    }
}
