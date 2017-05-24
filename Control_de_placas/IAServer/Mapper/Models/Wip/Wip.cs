using Newtonsoft.Json;

namespace Control_de_placas.IAServer.Mapper.Models
{
    public class Wip
    {
        [JsonProperty("active")]
        public bool active{ get; set; }
        
        [JsonProperty("wip_ot")]
        public WipOt wip_ot { get; set; }
    }
}
