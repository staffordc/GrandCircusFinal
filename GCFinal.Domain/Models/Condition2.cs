using Newtonsoft.Json;

namespace GCFinal.Domain.Models
{
    public class Condition2
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("code")]
        public int Code { get; set; }
    }
}
