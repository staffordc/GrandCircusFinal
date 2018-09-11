using GCFinal.Data;
using GCFinal.MVC.Client;
using GCFinal.MVC.Models;
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

        public PackingListController()
        {
            _weatherClient = new WeatherClient();
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
            var avgPrecipitationMillimeters = weatherObject.SelectMany(x => x.Hour).Select(x => x.precip_mm).Sum() / weatherObject.Count;
            var avgWindSpeedMph = weatherObject.SelectMany(x => x.Hour).Select(x => x.wind_mph).Sum() / weatherObject.Count;
            var avgDailyHighTempF = weatherObject.Select(x => x.Day).Select(x => x.MaxTempF).Average();
            var avgDailyLowTempF = weatherObject.Select(x => x.Day).Select(x => x.MinTempF).Average();
            var avgDailyAvgTempF = weatherObject.Select(x => x.Day).Select(x => x.AvgTempF).Average();
            var avgHumidityPercent = weatherObject.SelectMany(x => x.Hour).Select(x => x.humidity).Sum() /
                                     weatherObject.Count;
            var vm = new WeatherViewModel()
            {
                AvgPrecip = avgPrecipitationMillimeters,
                AvgWind = avgWindSpeedMph,
                DailyMaxTemp = avgDailyHighTempF,
                DailyMinTemp = avgDailyLowTempF,
                DailyAvgTemp = avgDailyAvgTempF,
                AvgHumidity = avgHumidityPercent
            };
            return RedirectToAction("Result", vm);
        }

        public ActionResult Result(WeatherViewModel model)
        {
            return View(model);
        }
    }
}