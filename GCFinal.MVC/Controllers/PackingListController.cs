﻿using GCFinal.Domain.Models;
using GCFinal.Domain.Models.BinPackingModels;
using GCFinal.Domain.Models.PackingModels;
using GCFinal.MVC.Client;
using GCFinal.MVC.Models;
using GCFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GCFinal.MVC.Controllers
{
    public class PackingListController : Controller
    {
        private readonly WeatherClient _weatherClient;

        private readonly TripPackingService _tripPackingService;

        private readonly SuitcasePackingService _suitcasePackingService;

        public PackingListController()
        {
            _weatherClient = new WeatherClient();
            _tripPackingService = new TripPackingService();
            _suitcasePackingService = new SuitcasePackingService(new ContainerService());
        }

        // GET: PackingList
        public ActionResult Index()
        {
            return View();
        }
        private WeatherModel MapForecast(List<RootObject> forecastDays)
        {
            var hourlies = forecastDays.Select(x => x.Forecast).SelectMany(x => x.ForecastDay).SelectMany(x => x.Hours).ToList();
            var dailies = forecastDays.Select(x => x.Forecast).SelectMany(x => x.ForecastDay).Select(x => x.Day).ToList();
            var countOfDailies = dailies.Count();
            var avgPrecipitationMillimeters = hourlies.Sum(x => x.PrecipMm) / countOfDailies;
            var avgWindSpeedMph = hourlies.Average(x => x.WindMph);
            var avgDailyHighTempF = dailies.Average(x => x.MaxTempF);
            var avgDailyLowTempF = dailies.Average(x => x.MinTempF);
            var avgDailyAvgTempF = dailies.Average(x => x.AvgTempF);
            var avgHumidityPercent = hourlies.Average(x => x.Humidity);
            return new WeatherModel()
            {
                DailyMaxTemp = avgDailyHighTempF,
                DailyMinTemp = avgDailyLowTempF,
                DailyAvgTemp = avgDailyAvgTempF,
                AvgPrecip = avgPrecipitationMillimeters,
                AvgHumidity = avgHumidityPercent,
                AvgWind = avgWindSpeedMph
            };
        }

        private IEnumerable<PackingItem> GetPackingItems(WeatherModel model, int duration)
        {
            _tripPackingService
                .PackItems(model.DailyAvgTemp, model.AvgPrecip, model.AvgWind, Convert.ToDecimal(duration));
            return this._tripPackingService.GetPackedItems().ToList();
        }

        public async Task<ActionResult> GetWeatherObject(SearchModel model)
        {
            if (ModelState.IsValid)
            {
                var vm = new WeatherViewModel();
                var trip = new Trip()
                {
                    Location = model.Location,
                    StartDate = model.StartDate,
                    Duration = model.Duration
                };
                _tripPackingService.CreateTrip(trip);
                var historicalWeather = await _weatherClient.GetHistoricalWeather(model.Location, model.StartDate, model.Duration);
                var cityName = historicalWeather.Select(x => x.Location).Select(x => x.Name).Distinct().FirstOrDefault();
                var regionName = historicalWeather.Select(x => x.Location).Select(x => x.Region).Distinct().FirstOrDefault();
                vm.Historicals = MapForecast(historicalWeather);
                vm.CityName = cityName;
                vm.RegionName = regionName;
                vm.StartDate = model.StartDate.ToString("d");
                vm.EndDate = model.StartDate.AddDays(model.Duration - 1).ToString("d");
                if (model.StartDate <= DateTime.Now.AddDays(5))
                {
                    TimeSpan interval = model.StartDate - DateTime.Today;
                    var days = model.Duration + interval.Days;
                    if (days > 10)
                    {
                        var forecastWeather10Days = await _weatherClient.GetForecastWeather(model.Location, 10);
                        vm.Forecasts = MapForecast(forecastWeather10Days);
                    }
                    var forecastWeather = await _weatherClient.GetForecastWeather(model.Location, days);
                    vm.Forecasts = MapForecast(forecastWeather);

                }

                // the ?: is a ternary operator: this is what it does 
                // if vm.forecasts is not null, then get items based on forcasts; otherwise, get items based on historicals 
                var itemsToPack = GetPackingItems(
                    vm.Forecasts != null
                        ? vm.Forecasts
                        : vm.Historicals,
                    model.Duration);

                List<Item> itemsToContainer = new List<Item>();
                foreach (var item in itemsToPack)
                {
                    itemsToContainer.Add(new Item(item.Name, item.Height, item.Length, item.Width, Convert.ToInt32(item.Quantity)));
                }

                var result = _suitcasePackingService.Pack(itemsToContainer);
                vm.ContainerPackingResults = result.Items;
                vm.TotalWeightInLbs = result.GetTotalWeight() * 0.0625M; //converts weight in ounces to pounds
                vm.PackingItems = itemsToPack;

                return View("Result", vm);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Result(WeatherViewModel model)
        {
            return View(model);
        }
    }
}