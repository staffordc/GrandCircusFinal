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
                var avgPrecipitationMillimeters = decimal.Round((weatherObject.SelectMany(x => x.Hours).Select(x => x.PrecipMm).Sum() / weatherObject.Count), 2, MidpointRounding.AwayFromZero);
                var avgWindSpeedMph = decimal.Round((weatherObject.SelectMany(x => x.Hours).Select(x => x.WindMph).Sum() / weatherObject.Count / 24), 2, MidpointRounding.AwayFromZero);
                var avgDailyHighTempF = decimal.Round((weatherObject.Select(x => x.Day).Select(x => x.MaxTempF).Average()), 2, MidpointRounding.AwayFromZero);
                var avgDailyLowTempF = decimal.Round((weatherObject.Select(x => x.Day).Select(x => x.MinTempF).Average()));
                var avgDailyAvgTempF = decimal.Round((weatherObject.Select(x => x.Day).Select(x => x.AvgTempF).Average()), 2, MidpointRounding.AwayFromZero);
                var avgHumidityPercent = decimal.Round((weatherObject.SelectMany(x => x.Hours).Select(x => x.Humidity).Sum() /
                                                        weatherObject.Count / 24), 2, MidpointRounding.AwayFromZero);
                var historicalModel = new HistoricalWeatherModel()
                {
                    DailyMaxTemp = avgDailyHighTempF,
                    DailyMinTemp = avgDailyLowTempF,
                    DailyAvgTemp = avgDailyAvgTempF,
                    AvgPrecip = avgPrecipitationMillimeters,
                    AvgHumidity = avgHumidityPercent,
                    AvgWind = avgWindSpeedMph
                };

                var durationDeciaml = Convert.ToDecimal(model.Duration);
                var itemsToPack =
                    _tripPackingService.PackItems(avgDailyAvgTempF, avgPrecipitationMillimeters, avgWindSpeedMph, durationDeciaml).ToList();
                List<Container> containers = new List<Container>();
                containers.Add(new Container(1, "Carry-On", 20.5M, 15M, 8M)); //samsonite 21" Spinner
                containers.Add(new Container(2, "Medium Suitcase", 27M, 18.5M, 9.5M)); //samsonite 27" Spinner (27M, 18.5M,9.5M)
                containers.Add(new Container(3, "Large Suitcase", 33.5M, 22M, 11M));
                List<Item> itemsToContainer = new List<Item>();
                foreach (var item in itemsToPack)
                {
                    itemsToContainer.Add(new Item(item.Name, item.Height, item.Length, item.Width, Convert.ToInt32(item.Quantity)));
                }
                List<int> algorithms = new List<int>();
                algorithms.Add((int)AlgorithmType.EB_AFIT);
                List<ContainerPackingResult> packingResults = new List<ContainerPackingResult>();
                vm.Historicals = historicalModel;
                
                for (int i = containers.Count - 1; i >= 0; i--)
                {
                    packingResults = PackingService.Pack(containers[i], itemsToContainer, algorithms);
                    var packResult = packingResults.SelectMany(x => x.AlgorithmPackingResults).SelectMany(x => x.UnpackedItems).Count();
                    if (packResult == 0)
                    {
                        vm.PackingItems = itemsToPack;
                        vm.ContainerPackingResults = packingResults;
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