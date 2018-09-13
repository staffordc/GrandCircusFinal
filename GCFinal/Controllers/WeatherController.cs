using GCFinal.Domain.Data;
using System.Collections.Generic;
using System.Web.Http;
using GCFinal.Services;
using System;
using System.Linq;
using GCFinal.Domain.Models;
using System.Threading.Tasks;

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
        public async Task<List<ForecastDay>> GetWeatherAsync(string location, DateTime startDate, int duration)
        {
            var dateOneYearAgo = startDate.AddYears(-1);
            var oneYearAgo = await _weatherService.GetWeatherAsync(location, dateOneYearAgo, duration);
            var dateTwoYearsAgo = startDate.AddYears(-2);
            var twoYearsAgo = await _weatherService.GetWeatherAsync(location, dateTwoYearsAgo, duration);
            var dateThreeYearsAgo = startDate.AddYears(-3);
            var threeYearsAgo = await _weatherService.GetWeatherAsync(location, dateThreeYearsAgo, duration);
            List<ForecastDay> items = new List<ForecastDay>();
            items.AddRange(oneYearAgo);
            items.AddRange(twoYearsAgo);
            items.AddRange(threeYearsAgo);
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
