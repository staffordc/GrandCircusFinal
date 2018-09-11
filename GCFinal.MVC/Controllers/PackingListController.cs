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
            var avgPrecipitationMillimeters = (weatherObject.SelectMany(x => x.hour).Select(x => x.precip_mm).Sum() / weatherObject.Count).ToString("f2");
            var avgWindSpeedMph = (weatherObject.SelectMany(x => x.hour).Select(x => x.wind_mph).Sum() / weatherObject.Count / 24).ToString("f2");
            var avgDailyHighTempF = weatherObject.Select(x => x.day).Select(x => x.maxtemp_f).Average().ToString("f2");
            var avgDailyLowTempF = weatherObject.Select(x => x.day).Select(x => x.mintemp_f).Average().ToString("f2");
            var avgDailyAvgTempF = weatherObject.Select(x => x.day).Select(x => x.avgtemp_f).Average().ToString("f2");
            var avgHumidityPercent = (weatherObject.SelectMany(x => x.hour).Select(x => x.humidity).Sum() /
                                     weatherObject.Count / 24).ToString("f2");
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