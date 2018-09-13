using Newtonsoft.Json;

namespace GCFinal.Domain.Models

{
    public class Day
    {
        [JsonProperty("maxtemp_c")]
        public decimal MaxTempC { get; set; }
        [JsonProperty("maxtemp_f")]
        public decimal MaxTempF { get; set; }
        [JsonProperty("mintemp_c")]
        public decimal MinTempC { get; set; }
        [JsonProperty("mintemp_f")]
        public decimal MinTempF { get; set; }
        [JsonProperty("avgtemp_c")]
        public decimal AvgTempC { get; set; }
        [JsonProperty("avgtemp_f")]
        public decimal AvgTempF { get; set; }
        [JsonProperty("maxwind_mph")]
        public decimal MaxWindMph { get; set; }
        [JsonProperty("maxwind_kph")]
        public decimal MaxWindKph { get; set; }
        [JsonProperty("totalprecip_mm")]
        public decimal TotalPrecipMm { get; set; }
        [JsonProperty("totalprecip_in")]
        public decimal TotalPrecipIn { get; set; }
        [JsonProperty("avgvis_km")]
        public decimal AvgVisKm { get; set; }
        [JsonProperty("avgvis_miles")]
        public decimal AvgVisMiles { get; set; }
        [JsonProperty("avghumidity")]
        public decimal AvgHumidity { get; set; }
        [JsonProperty("condition")]
        public Condition Condition { get; set; }
        [JsonProperty("uv")]
        public decimal Uv { get; set; }
    }
}
