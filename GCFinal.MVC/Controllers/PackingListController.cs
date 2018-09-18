using GCFinal.Domain.Algorithms;
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
                var weatherObject = await _weatherClient.GetHistoricalWeather(model.Location, model.StartDate, model.Duration);
                var avgPrecipitationMillimeters = decimal.Round((weatherObject.SelectMany(x => x.Hours).Select(x => x.PrecipMm).Sum() / weatherObject.Count), 2, MidpointRounding.AwayFromZero);
                var avgWindSpeedMph = decimal.Round((weatherObject.SelectMany(x => x.Hours).Select(x => x.WindMph).Sum() / weatherObject.Count / 24), 2, MidpointRounding.AwayFromZero);
                var avgDailyHighTempF = decimal.Round((weatherObject.Select(x => x.Day).Select(x => x.MaxTempF).Average()), 2, MidpointRounding.AwayFromZero);
                var avgDailyLowTempF = decimal.Round((weatherObject.Select(x => x.Day).Select(x => x.MinTempF).Average()));
                var avgDailyAvgTempF = decimal.Round((weatherObject.Select(x => x.Day).Select(x => x.AvgTempF).Average()), 2, MidpointRounding.AwayFromZero);
                var avgHumidityPercent = decimal.Round((weatherObject.SelectMany(x => x.Hours).Select(x => x.Humidity).Sum() /
                                                        weatherObject.Count / 24), 2, MidpointRounding.AwayFromZero);
                var durationDeciaml = Convert.ToDecimal(model.Duration);
                var itemsToPack = _tripPackingService.PackItems(avgDailyAvgTempF, avgPrecipitationMillimeters, avgWindSpeedMph, durationDeciaml).ToList();
                var totalItemWeight = itemsToPack.Select(x => x.TotalWeight).Sum();
                List<Container> containers = new List<Container>();
                containers.Add(new Container(1, "Carry-On", 104M, 20.5M, 15M, 8M)); //samsonite 21" Spinner
                containers.Add(new Container(2, "Medium Suitcase", 144.88M, 27M, 18.5M, 9.5M)); //samsonite 27" Spinner (27M, 18.5M,9.5M)
                containers.Add(new Container(3, "Large Suitcase", 145.6M, 33.5M, 22M, 11M));
                List<Item> itemsToContainer = new List<Item>();
                foreach (var item in itemsToPack)
                {
                    itemsToContainer.Add(new Item(item.Name, item.Height, item.Length, item.Width, Convert.ToInt32(item.Quantity)));
                }
                List<int> algorithms = new List<int>();
                algorithms.Add((int)AlgorithmType.EB_AFIT);
                List<ContainerPackingResult> packingResults = new List<ContainerPackingResult>();
                var vm = new WeatherViewModel();
                for (int i = containers.Count - 1; i >= 0; i--)
                {
                    packingResults = PackingService.Pack(containers[i], itemsToContainer, algorithms);
                    var packResult = packingResults.SelectMany(x => x.AlgorithmPackingResults).SelectMany(x => x.UnpackedItems).Count();
                    if (packResult == 0)
                    {
                        var containerWeight = packingResults.Select(x => x.Weight).Sum();
                        var totalWeight = (containerWeight + totalItemWeight) * .0625M; //converts weight in ounces to pounds
                        vm.AvgPrecip = avgPrecipitationMillimeters;
                        vm.AvgWind = avgWindSpeedMph;
                        vm.DailyMaxTemp = avgDailyHighTempF;
                        vm.DailyMinTemp = avgDailyLowTempF;
                        vm.DailyAvgTemp = avgDailyAvgTempF;
                        vm.AvgHumidity = avgHumidityPercent;
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