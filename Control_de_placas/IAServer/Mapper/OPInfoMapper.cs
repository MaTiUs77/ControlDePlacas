using Control_de_placas.IAServer.Mapper.Models;
using Newtonsoft.Json;

namespace Control_de_placas.IAServer.Mapper
{
    public class OPInfoMapper
    {
        [JsonProperty("error")]
        public string error { get; set; }

        [JsonProperty("op")]
        public string op { get; set; }

        [JsonProperty("wip")]
        public Wip wip { get; set; }

        [JsonProperty("smt")]
        public Smt smt { get; set; }
    }
}
