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
    }
}