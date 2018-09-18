using System.Collections.Generic;
using System.Linq;
using GCFinal.Domain.Models.BinPackingModels;
using GCFinal.Domain.Models.PackingModels;

namespace GCFinal.MVC.Models
{
    public class WeatherViewModel
    {
        public ForecastWeatherModel Forecasts { get; set; }
        public HistoricalWeatherModel Historicals { get; set; }
        public List<PackingItem> PackingItems { get; set; }
        public List<ContainerPackingResult> ContainerPackingResults { get; set; }

    }
}