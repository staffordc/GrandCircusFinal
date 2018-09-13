using Newtonsoft.Json;

namespace GCFinal.Domain.Models
{
    public class Hour
    {
        [JsonProperty("time_epoch")]
        public decimal TimeEpoch { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("temp_c")]
        public decimal TempC { get; set; }
        [JsonProperty("temp_f")]
        public decimal TempF { get; set; }
        [JsonProperty("is_day")]
        public decimal IsDay { get; set; }
        [JsonProperty("condition")]
        public Condition2 Condition { get; set; }
        [JsonProperty("wind_mph")]
        public decimal WindMph { get; set; }
        [JsonProperty("wind_kph")]
        public decimal WindKph { get; set; }
        [JsonProperty("wind_degree")]
        public decimal WindDegree { get; set; }
        [JsonProperty("wind_dir")]
        public string WindDir { get; set; }
        [JsonProperty("pressure_mb")]
        public decimal PressureMb { get; set; }
        [JsonProperty("pressure_in")]
        public decimal PressureIn { get; set; }
        [JsonProperty("precip_mm")]
        public decimal PrecipMm { get; set; }
        [JsonProperty("precip_in")]
        public decimal PrecipIn { get; set; }
        [JsonProperty("humidity")]
        public decimal Humidity { get; set; }
        [JsonProperty("cloud")]
        public decimal Cloud { get; set; }
        [JsonProperty("feelslike_c")]
        public decimal FeelsLikeC { get; set; }
        [JsonProperty("feelslike_f")]
        public decimal FeelsLikeF { get; set; }
        [JsonProperty("windchill_c")]
        public decimal WindchillC { get; set; }
        [JsonProperty("windchill_f")]
        public decimal WindchillF { get; set; }
        [JsonProperty("heatindex_c")]
        public decimal HeatIndexC { get; set; }
        [JsonProperty("heatindex_f")]
        public decimal HeatIndexF { get; set; }
        [JsonProperty("dewpoint_c")]
        public decimal DewpointC { get; set; }
        [JsonProperty("dewpoint_f")]
        public decimal DewpointF { get; set; }
        [JsonProperty("will_it_rain")]
        public decimal WillItRain { get; set; }
        [JsonProperty("chance_of_rain")]
        public string ChanceOfRain { get; set; }
        [JsonProperty("will_it_snow")]
        public decimal WillItSnow { get; set; }
        [JsonProperty("chance_of_snow")]
        public string ChanceOfSnow { get; set; }
        [JsonProperty("vis_km")]
        public decimal VisKm { get; set; }
        [JsonProperty("vis_miles")]
        public decimal VisMiles { get; set; }
    }
}
