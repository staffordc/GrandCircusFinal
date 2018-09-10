using GCFinal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCFinal.Models
{
    public class WeatherViewModel
    {
        public double DailyMaxTemp { get; set; }
        public double DailyMinTemp { get; set; }
        public double DailyAvgTemp { get; set; }
        public string AstroSunrise { get; set; }
        public string ConIcon1 { get; set; }
        public string ConIcon2 { get; set; }
        public double MaxWind { get; set; }
        public double TotalPrecipMm { get; set; }
        public double AvgHumidity { get; set; }
        public string WindDirection { get; set; }
        public string ChanceOfSnow { get; set; }
        public string LocationName { get; set; }
        public Forecast Forecast { get; set; }

        //Convert.ToSingle(info needed to be changed to float or w/e num type)

        public WeatherViewModel(ForecastDay forecastDay, Astro astro, Condition condition, Condition2 condition2,
            Day day, Hour hour, Location location, Forecast forecast)
        {
            DailyMaxTemp = forecastDay.Day.MaxTempF;
            DailyMinTemp = forecastDay.Day.MinTempF;
            DailyAvgTemp = forecastDay.Day.AvgTempF;
            AstroSunrise = forecastDay.Astro.Sunrise;
            ConIcon1 = condition.Icon;
            ConIcon2 = condition.Icon;
            MaxWind = day.MaxWindMph;
            TotalPrecipMm = day.TotalPrecipMm;
            AvgHumidity = day.AvgHumidity;
            WindDirection = hour.WindDir;
            ChanceOfSnow = hour.ChanceOfSnow;
            LocationName = location.Name;
            
        }
    }
}