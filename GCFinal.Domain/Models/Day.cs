using Newtonsoft.Json;

namespace GCFinal.Domain.Models

{
    public class Day
    {
        [JsonProperty("maxtemp_c")]
        public double MaxTempC { get; set; }
        [JsonProperty("maxtemp_f")]
        public double MaxTempF { get; set; }
        [JsonProperty("mintemp_c")]
        public double MinTempC { get; set; }
        [JsonProperty("mintemp_f")]
        public double MinTempF { get; set; }
        [JsonProperty("avgtemp_c")]
        public double AvgTempC { get; set; }
        [JsonProperty("avgtemp_f")]
        public double AvgTempF { get; set; }
        [JsonProperty("maxwind_mph")]
        public double MaxWindMph { get; set; }
        [JsonProperty("maxwind_kph")]
        public double MaxWindKph { get; set; }
        [JsonProperty("totalprecip_mm")]
        public double TotalPrecipMm { get; set; }
        [JsonProperty("totalprecip_in")]
        public double TotalPrecipIn { get; set; }
        [JsonProperty("avgvis_km")]
        public double AvgVisKm { get; set; }
        [JsonProperty("avgvis_miles")]
        public int AvgVisMiles { get; set; }
        [JsonProperty("avghumidity")]
        public int AvgHumidity { get; set; }
        [JsonProperty("condition")]
        public Condition Condition { get; set; }
        [JsonProperty("uv")]
        public int Uv { get; set; }
    }
}
