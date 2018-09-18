using GCFinal.Domain.Models.BinPackingModels;
using GCFinal.Domain.Models.PackingModels;
using System.Collections.Generic;

namespace GCFinal.MVC.Models
{
    public class WeatherViewModel
    {
        public ForecastWeatherModel Forecasts { get; set; }
        public HistoricalWeatherModel Historicals { get; set; }
        public List<PackingItem> PackingItems { get; set; }
        public List<ContainerPackingResult> ContainerPackingResults { get; set; }
        public decimal TotalWeightInLbs { get; set; }
    }
}