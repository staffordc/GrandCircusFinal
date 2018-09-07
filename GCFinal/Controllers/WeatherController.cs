using GCFinal.Domain.Data;
using System.Collections.Generic;
using System.Web.Http;

namespace GCFinal.Controllers
{
    public class WeatherController : ApiController
    {
        private readonly IWeatherService _weatherService;

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
