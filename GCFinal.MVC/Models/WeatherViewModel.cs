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
        public string DailyMaxTemp { get; set; }
        public string DailyMinTemp { get; set; }
        public string DailyAvgTemp { get; set; }
        public string AvgWind { get; set; }
        public string AvgPrecip { get; set; }
        public string AvgHumidity { get; set; }
        public string ItemName { get; set; }
    }
}