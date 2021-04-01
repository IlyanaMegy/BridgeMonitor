using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BridgeMonitor.Models
{
    // Hours myDeserializedClass = JsonConvert.DeserializeObject<Hours>(myJsonResponse); 
    public class Hours
    {
        [JsonProperty("boat_name")]
        public string BoatName { get; set; }

        [JsonProperty("closing_type")]
        public string ClosingType { get; set; }

        [JsonProperty("closing_date")]
        public DateTime ClosingDate { get; set; }

        [JsonProperty("reopening_date")]
        public DateTime ReopeningDate { get; set; }
    }
}
