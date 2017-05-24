using Newtonsoft.Json;

namespace Control_de_placas.IAServer.Mapper.Models
{
    public class PlacaWip
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("nro_op")]
        public string nro_op { get; set; }

        [JsonProperty("nro_informe")]
        public int? nro_informe { get; set; }

        [JsonProperty("codigo_producto")]
        public string codigo_producto { get; set; }

        [JsonProperty("cantidad")]
        public string cantidad { get; set; }

        [JsonProperty("referencia_1")]
        public string referencia_1 { get; set; }

        [JsonProperty("fecha_proceso")]
        public string fecha_proceso { get; set; }

        [JsonProperty("trans_ok")]
        public string trans_ok { get; set; }

        [JsonProperty("ebs_error_desc")]
        public string ebs_error_desc { get; set; }

        [JsonProperty("ebs_error_trans")]
        public string ebs_error_trans { get; set; }

        [JsonProperty("fecha_insercion")]
        public string fecha_insercion { get; set; }
    }
}
