using Newtonsoft.Json;

namespace GCFinal.Domain.Models

{
    public class Day
    {
        [JsonProperty("maxtemp_c")]
        public double MaxtempC { get; set; }
        [JsonProperty("maxtemp_f")]
        public double MaxtempF { get; set; }
        [JsonProperty("mintemp_c")]
        public double MintempC { get; set; }
        [JsonProperty("mintemp_f")]
        public double MintempF { get; set; }
        [JsonProperty("avgtemp_c")]
        public double AvgtempC { get; set; }
        [JsonProperty("avgtemp_f")]
        public double AvgtempF { get; set; }
        //[JsonProperty("maxwind_mph")]
        //public double MaxWindMph { get; set; }
        //[JsonProperty("maxwind_kph")]
        //public double MaxWindKph { get; set; }
        //[JsonProperty("totalprecip_mm")]
        //public double TotalPrecipMm { get; set; }
        //[JsonProperty("totalprecip_in")]
        //public double TotalPrecipIn { get; set; }
        //[JsonProperty("avgvis_km")]
        //public double AvgVisKm { get; set; }
        //[JsonProperty("avgvis_miles")]
        //public double AvgVisMiles { get; set; }
        //[JsonProperty("avghumidity")]
        //public double AvgHumidity { get; set; }
        //[JsonProperty("condition")]
        //public Condition Condition { get; set; }
        //[JsonProperty("uv")]
        //public double Uv { get; set; }
    }
}
