using GCFinal.Data;
using GCFinal.MVC.Client;
using GCFinal.MVC.Models;
using GCFinal.Services;
using System;
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
                _tripPackingService.PackItems(avgDailyAvgTempF, avgPrecipitationMillimeters, avgWindSpeedMph, durationDeciaml);
            var vm = new WeatherViewModel()
            {
                AvgPrecip = avgPrecipitationMillimeters,
                AvgWind = avgWindSpeedMph,
                DailyMaxTemp = avgDailyHighTempF,
                DailyMinTemp = avgDailyLowTempF,
                DailyAvgTemp = avgDailyAvgTempF,
                AvgHumidity = avgHumidityPercent,
                PackingItems = itemsToPack.ToList()
            };
            return View("Result", vm);
        }

        public ActionResult Result(WeatherViewModel model)
        {
            return View(model);
        }
    }
}