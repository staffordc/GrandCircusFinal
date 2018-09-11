using System.Collections.Generic;
using System.Linq;
using GCFinal.Domain.Models.Items;

namespace GCFinal.MVC.Models
{
    public class WeatherViewModel
    {
        public decimal DailyMaxTemp { get; set; }
        public decimal DailyMinTemp { get; set; }
        public decimal DailyAvgTemp { get; set; }
        public decimal AvgWind { get; set; }
        public decimal AvgPrecip { get; set; }
        public decimal AvgHumidity { get; set; }
        public List<object> ItemName { get; set; }
    }
}