using GCFinal.Domain.Algorithms;
using GCFinal.Domain.Models;
using GCFinal.Domain.Models.BinPackingModels;
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

        public PackingListController()
        {
            _weatherClient = new WeatherClient();
            _tripPackingService = new TripPackingService();
        }
        // GET: PackingList
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetWeatherObject(SearchModel model)
        {
            if (ModelState.IsValid)
            {
                var vm = new WeatherViewModel();
                List<ForecastDay> forecastObject = new List<ForecastDay>();
                var forecastWeatherModels = new ForecastWeatherModel();
                decimal fAvgPrecipitationMillimeters;
                decimal fAvgWindSpeedMph;
                decimal fAvgDailyHighTempF;
                decimal fAvgDailyLowTempF;
                decimal fAvgDailyAvgTempF;
                decimal fAvgHumidityPercent;

                var weatherObject = await _weatherClient.GetHistoricalWeather(model.Location, model.StartDate, model.Duration);
                if (model.StartDate <= DateTime.Now.AddDays(10))
                {
                    forecastObject = await _weatherClient.GetForecastWeather(model.Location, model.Duration);
                    fAvgPrecipitationMillimeters = decimal.Round((forecastObject.SelectMany(x => x.Hours).Select(x => x.PrecipMm).Sum() / forecastObject.Count), 2, MidpointRounding.AwayFromZero);
                    fAvgWindSpeedMph = decimal.Round((forecastObject.SelectMany(x => x.Hours).Select(x => x.WindMph).Sum() / forecastObject.Count / 24), 2, MidpointRounding.AwayFromZero);
                    fAvgDailyHighTempF = decimal.Round((forecastObject.Select(x => x.Day).Select(x => x.MaxTempF).Average()), 2, MidpointRounding.AwayFromZero);
                    fAvgDailyLowTempF = decimal.Round((forecastObject.Select(x => x.Day).Select(x => x.MinTempF).Average()));
                    fAvgDailyAvgTempF = decimal.Round((forecastObject.Select(x => x.Day).Select(x => x.AvgTempF).Average()), 2, MidpointRounding.AwayFromZero);
                    fAvgHumidityPercent = decimal.Round((forecastObject.SelectMany(x => x.Hours).Select(x => x.Humidity).Sum() /
                                                         forecastObject.Count / 24), 2, MidpointRounding.AwayFromZero);

                    forecastWeatherModels.DailyMaxTemp = fAvgDailyAvgTempF;
                    forecastWeatherModels.DailyAvgTemp = fAvgDailyAvgTempF;
                    forecastWeatherModels.DailyMinTemp = fAvgDailyLowTempF;
                    forecastWeatherModels.AvgPrecip = fAvgPrecipitationMillimeters;
                    forecastWeatherModels.AvgHumidity = fAvgHumidityPercent;
                    forecastWeatherModels.AvgWind = fAvgWindSpeedMph;
                    vm.Forecasts = forecastWeatherModels;
                }
                var hourlies = weatherObject.SelectMany(x => x.Hours).ToList();
                var dailies = weatherObject.Select(x => x.Day).ToList();
                var countOfDailies = dailies.Count();
                var avgPrecipitationMillimeters = hourlies.Sum(x => x.PrecipMm) / countOfDailies;
                var avgWindSpeedMph = hourlies.Average(x => x.WindMph);
                var avgDailyHighTempF = dailies.Average(x => x.MaxTempF);
                var avgDailyLowTempF = dailies.Average(x => x.MinTempF);
                var avgDailyAvgTempF = dailies.Average(x => x.AvgTempF);
                var avgHumidityPercent = hourlies.Average(x => x.Humidity);
                var historicalModel = new HistoricalWeatherModel()
                {
                    DailyMaxTemp = avgDailyHighTempF,
                    DailyMinTemp = avgDailyLowTempF,
                    DailyAvgTemp = avgDailyAvgTempF,
                    AvgPrecip = avgPrecipitationMillimeters,
                    AvgHumidity = avgHumidityPercent,
                    AvgWind = avgWindSpeedMph
                };
                var itemsToPack = this._tripPackingService.PackItems(avgDailyAvgTempF, avgPrecipitationMillimeters, avgWindSpeedMph, Convert.ToDecimal(model.Duration)).ToList();
                List<Container> containers = new List<Container>();
                containers.Add(new Container(1, "Carry-On", 104M, 20.5M, 15M, 8M)); //samsonite 21" Spinner - 43.5 total
                containers.Add(new Container(2, "Medium Suitcase", 144.88M, 23M, 17M, 99M)); //samsonite 27" Spinner (27M, 18.5M,9.5M) - 55 total
                containers.Add(new Container(3, "Large Suitcase", 145.6M, 29.5M, 20.5M, 11M)); //62" (must be 62" and 50 lbs or less)
                List<Item> itemsToContainer = new List<Item>();
                foreach (var item in itemsToPack)
                {
                    itemsToContainer.Add(new Item(item.Name, item.Height, item.Length, item.Width, Convert.ToInt32(item.Quantity)));
                }
                List<int> algorithms = new List<int>();
                algorithms.Add((int)AlgorithmType.EB_AFIT);
                List<ContainerPackingResult> packingResults = new List<ContainerPackingResult>();
                vm.Historicals = historicalModel;
                var totalItemWeight = itemsToPack.Select(x => x.TotalWeight).Sum();
                for (int i = containers.Count - 1; i >= 0; i--)
                {
                    packingResults = PackingService.Pack(containers[i], itemsToContainer, algorithms);
                    var packResult = packingResults.SelectMany(x => x.AlgorithmPackingResults).SelectMany(x => x.UnpackedItems).Count();
                    if (packResult == 0)
                    {
                        var containerWeight = packingResults.Select(x => x.Weight).Sum();
                        var totalWeight = (containerWeight + totalItemWeight) * .0625M; //converts weight in ounces to pounds
                        vm.PackingItems = itemsToPack;
                        vm.ContainerPackingResults = packingResults;
                        vm.TotalWeightInLbs = totalWeight;
                    }
                }

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