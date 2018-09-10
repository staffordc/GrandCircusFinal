using GCFinal.Domain.Data;
using GCFinal.Domain.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace GCFinal.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IRestClient _client;

        public WeatherService()
        {
            _client = new RestClient(ConfigurationManager.AppSettings["BaseWeatherUri"]);
        }

        public async Task<List<ForecastDay>> GetWeatherAsync(string location, DateTime startDate, int duration)
        {
            var beginDate = startDate.ToString("yyyy/MM/dd");
            var endDate = startDate.AddDays(duration-1).ToString("yyyy/MM/dd");
            var request = new RestRequest(string.Format(ConfigurationManager.AppSettings["WeatherEndpoint"], location, beginDate, endDate), Method.GET);
            var response = await _client.ExecuteTaskAsync<RootObject>(request);
            return response.Data.forecast.forecastday;
        }

    }
}
