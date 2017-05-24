using Newtonsoft.Json;
using System.Collections.Generic;

namespace Control_de_placas.IAServer.Mapper.Models
{
    public class Cuarentena
    {
        [JsonProperty("isBlocked")]
        public bool isBlocked { get; set; }
    }
}
