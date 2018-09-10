using Newtonsoft.Json;

namespace GCFinal.Domain.Models
{
    public class Hour
    {
        [JsonProperty("time_epoch")]
        public int TimeEpoch { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("temp_c")]
        public double TempC { get; set; }
        [JsonProperty("temp_f")]
        public double TempF { get; set; }
        [JsonProperty("is_day")]
        public int IsDay { get; set; }
        [JsonProperty("condition")]
        public Condition2 Condition { get; set; }
        [JsonProperty("wind_mph")]
        public double WindMph { get; set; }
        [JsonProperty("wind_kph")]
        public double WindKph { get; set; }
        [JsonProperty("wind_degree")]
        public int WindDegree { get; set; }
        [JsonProperty("wind_dir")]
        public string WindDir { get; set; }
        [JsonProperty("pressure_mb")]
        public double PressureMb { get; set; }
        [JsonProperty("pressure_in")]
        public double PressureIn { get; set; }
        [JsonProperty("precip_mm")]
        public double PrecipMm { get; set; }
        [JsonProperty("precip_in")]
        public double PrecipIn { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
        [JsonProperty("Cloud")]
        public int Cloud { get; set; }
        [JsonProperty("feelslike_c")]
        public double FeelsLikeC { get; set; }
        [JsonProperty("feelslike_f")]
        public double FeelsLikeF { get; set; }
        [JsonProperty("windchill_c")]
        public double WindchillC { get; set; }
        [JsonProperty("windchill_f")]
        public double WindchillF { get; set; }
        [JsonProperty("heatindex_c")]
        public double HeatIndexC { get; set; }
        [JsonProperty("heatindex_f")]
        public double HeatIndexF { get; set; }
        [JsonProperty("dewpoint_c")]
        public double DewpointC { get; set; }
        [JsonProperty("dewpoint_f")]
        public double DewpointF { get; set; }
        [JsonProperty("will_it_rain")]
        public int WillItRain { get; set; }
        [JsonProperty("chance_of_rain")]
        public string ChanceOfRain { get; set; }
        [JsonProperty("will_it_snow")]
        public int WillItSnow { get; set; }
        [JsonProperty("chance_of_snow")]
        public string ChanceOfSnow { get; set; }
        [JsonProperty("vis_km")]
        public double VisKm { get; set; }
        [JsonProperty("vis_miles")]
        public double VisMiles { get; set; }
    }
}
