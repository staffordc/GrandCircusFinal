using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCFinal.MVC.Models
{
    public class WeatherModel
    {
        public decimal DailyMaxTemp { get; set; }
        public decimal DailyMinTemp { get; set; }
        public decimal DailyAvgTemp { get; set; }
        public decimal AvgWind { get; set; }
        public decimal AvgPrecip { get; set; }
        public decimal AvgHumidity { get; set; }
    }
}