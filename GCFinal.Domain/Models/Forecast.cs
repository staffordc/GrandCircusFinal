
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GCFinal.Domain.Models
{
    public class Forecast
    {
        [JsonProperty ("forecastday")]
        public List<ForecastDay> ForecastDay { get; set; }
    }
}
