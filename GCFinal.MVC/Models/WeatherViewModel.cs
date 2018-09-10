using GCFinal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GCFinal.Domain.Models.Items;

namespace GCFinal.MVC.Models
{
    public class WeatherViewModel
    {
        public double DailyMaxTemp { get; set; }
        public double DailyMinTemp { get; set; }
        public double DailyAvgTemp { get; set; }
        public double AvgWind { get; set; }
        public double AvgPrecip { get; set; }
        public double AvgHumidity { get; set; }
        public string ItemName { get; set; }
    }
}