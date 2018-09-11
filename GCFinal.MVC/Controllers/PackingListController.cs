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
        private GCFinalContext db = new GCFinalContext();
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
            var avgPrecipitationMillimeters = decimal.Round((weatherObject.SelectMany(x => x.hour).Select(x => x.precip_mm).Sum() / weatherObject.Count), 2, MidpointRounding.AwayFromZero);
            var avgWindSpeedMph = decimal.Round((weatherObject.SelectMany(x => x.hour).Select(x => x.wind_mph).Sum() / weatherObject.Count / 24), 2, MidpointRounding.AwayFromZero);
            var avgDailyHighTempF = decimal.Round((weatherObject.Select(x => x.day).Select(x => x.maxtemp_f).Average()), 2, MidpointRounding.AwayFromZero);
            var avgDailyLowTempF = decimal.Round((weatherObject.Select(x => x.day).Select(x => x.mintemp_f).Average()));
            var avgDailyAvgTempF = decimal.Round((weatherObject.Select(x => x.day).Select(x => x.avgtemp_f).Average()), 2, MidpointRounding.AwayFromZero);
            var avgHumidityPercent = decimal.Round((weatherObject.SelectMany(x => x.hour).Select(x => x.humidity).Sum() /
                                                    weatherObject.Count / 24), 2, MidpointRounding.AwayFromZero);
            var itemsToPack =
                _tripPackingService.ItemsToPack(avgDailyAvgTempF, avgPrecipitationMillimeters, avgWindSpeedMph);
            var vm = new WeatherViewModel()
            {
                AvgPrecip = avgPrecipitationMillimeters,
                AvgWind = avgWindSpeedMph,
                DailyMaxTemp = avgDailyHighTempF,
                DailyMinTemp = avgDailyLowTempF,
                DailyAvgTemp = avgDailyAvgTempF,
                AvgHumidity = avgHumidityPercent,
                ItemName = itemsToPack
            };
            return RedirectToAction("Result", vm);
        }

        public ActionResult Result(WeatherViewModel model)
        {
            return View(model);
        }
    }
}