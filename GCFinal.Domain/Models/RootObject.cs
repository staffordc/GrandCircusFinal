using Newtonsoft.Json;

namespace GCFinal.Domain.Models
{
    public class RootObject
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }
    }
}
