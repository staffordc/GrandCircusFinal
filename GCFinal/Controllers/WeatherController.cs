using GCFinal.Domain.Data;
using GCFinal.Domain.Models;
using GCFinal.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace GCFinal.Controllers
{
    public class WeatherController : ApiController
    {
        private readonly IWeatherService _weatherService;

        public WeatherController()
        {
            _weatherService = new WeatherService();
        }

        [HttpGet]
        public async Task<List<RootObject>> GetWeatherAsync(string location, DateTime startDate, int duration)
        {
            var dateOneYearAgo = startDate.AddYears(-1);
            var oneYearAgo = await _weatherService.GetHistoricalAsync(location, dateOneYearAgo, duration);
            var dateTwoYearsAgo = startDate.AddYears(-2);
            var twoYearsAgo = await _weatherService.GetHistoricalAsync(location, dateTwoYearsAgo, duration);
            var dateThreeYearsAgo = startDate.AddYears(-3);
            var threeYearsAgo = await _weatherService.GetHistoricalAsync(location, dateThreeYearsAgo, duration);
            List<RootObject> items = new List<RootObject>();
            items.Add(oneYearAgo);
            items.Add(twoYearsAgo);
            items.Add(threeYearsAgo);
            return items;
        }

        [HttpGet]
        public async Task<List<RootObject>> WeatherAsyncNow(string location, int duration)
        {
            var Now = await _weatherService.GetForecastAsync(location, duration);
            List<RootObject> items = new List<RootObject>();
            items.Add(Now);
            return items;
        }

        // GET: api/Weather
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Weather/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Weather
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Weather/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Weather/5
        public void Delete(int id)
        {
        }
    }
}
