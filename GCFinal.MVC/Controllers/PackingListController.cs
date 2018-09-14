using GCFinal.Data;
using GCFinal.MVC.Client;
using GCFinal.MVC.Models;
using GCFinal.Services;
using GCFinal.Domain.Models.BinPackingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using GCFinal.Domain.Algorithms;

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

        public async Task<ActionResult> GetWeatherObject(string location, DateTime startDate,
            int duration)
        {
            var weatherObject = await _weatherClient.GetHistoricalWeather(location, startDate, duration);
            var avgPrecipitationMillimeters = decimal.Round((weatherObject.SelectMany(x => x.Hours).Select(x => x.PrecipMm).Sum() / weatherObject.Count), 2, MidpointRounding.AwayFromZero);
            var avgWindSpeedMph = decimal.Round((weatherObject.SelectMany(x => x.Hours).Select(x => x.WindMph).Sum() / weatherObject.Count / 24), 2, MidpointRounding.AwayFromZero);
            var avgDailyHighTempF = decimal.Round((weatherObject.Select(x => x.Day).Select(x => x.MaxTempF).Average()), 2, MidpointRounding.AwayFromZero);
            var avgDailyLowTempF = decimal.Round((weatherObject.Select(x => x.Day).Select(x => x.MinTempF).Average()));
            var avgDailyAvgTempF = decimal.Round((weatherObject.Select(x => x.Day).Select(x => x.AvgTempF).Average()), 2, MidpointRounding.AwayFromZero);
            var avgHumidityPercent = decimal.Round((weatherObject.SelectMany(x => x.Hours).Select(x => x.Humidity).Sum() /
                                                    weatherObject.Count / 24), 2, MidpointRounding.AwayFromZero);
            var durationDeciaml = Convert.ToDecimal(duration);
            var itemsToPack =
                _tripPackingService.PackItems(avgDailyAvgTempF, avgPrecipitationMillimeters, avgWindSpeedMph, durationDeciaml).ToList();
            List<Container> containers = new List<Container>();
            containers.Add(new Container(1, 19, 14.5m, 9.8m));
            List<Item> itemsToContainer = new List<Item>();
            foreach (var item in itemsToPack)
            {
                itemsToContainer.Add(new Item(item.Id, item.Height, item.Length, item.Width, Convert.ToInt32(item.Quantity)));
            }
            List<int> algorithms = new List<int>();
            algorithms.Add((int)AlgorithmType.EB_AFIT);
            var packingResults = PackingService.Pack(containers, itemsToContainer, algorithms);
            var vm = new WeatherViewModel()
            {
                AvgPrecip = avgPrecipitationMillimeters,
                AvgWind = avgWindSpeedMph,
                DailyMaxTemp = avgDailyHighTempF,
                DailyMinTemp = avgDailyLowTempF,
                DailyAvgTemp = avgDailyAvgTempF,
                AvgHumidity = avgHumidityPercent,
                PackingItems = itemsToPack,
                ContainerPackingResults = packingResults
            };
            return View("Result", vm);
        }

        public ActionResult Result(WeatherViewModel model)
        {
            return View(model);
        }
    }
}