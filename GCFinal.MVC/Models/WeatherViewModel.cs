using GCFinal.Domain.Models.BinPackingModels;
using GCFinal.Domain.Models.PackingModels;
using System.Collections.Generic;

namespace GCFinal.MVC.Models
{
    public class WeatherViewModel
    {
        public WeatherModel Forecasts { get; set; }
        public WeatherModel Historicals { get; set; }
        public IEnumerable<PackingItem> PackingItems { get; set; }
        public IEnumerable<ContainerPackingResult> ContainerPackingResults { get; set; }
        public decimal TotalWeightInLbs { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}