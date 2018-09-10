﻿using GCFinal.Domain.Models;
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
        
        public double MaxWind { get; set; }
        public double TotalPrecipMm { get; set; }
        public double AvgHumidity { get; set; }
        public double WindMph { get; set; }
        

        //Convert.ToSingle(info needed to be changed to float or w/e num type)

        public WeatherViewModel(ForecastDay forecastDay, Astro astro, Condition condition, Condition2 condition2,
            Day day, Hour hour, Location location, Forecast forecast)
        {
            DailyMaxTemp = forecastDay.Day.MaxTempF;
            DailyMinTemp = forecastDay.Day.MinTempF;
            DailyAvgTemp = forecastDay.Day.AvgTempF;
            MaxWind = day.MaxWindMph;
            TotalPrecipMm = day.TotalPrecipMm;
            AvgHumidity = day.AvgHumidity;
            WindMph = hour.WindMph;
            
            
        }
    }
}