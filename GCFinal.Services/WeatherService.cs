using GCFinal.Domain.Data;
using GCFinal.Domain.Models;
using RestSharp;
using System;
using System.Configuration;
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

        public async Task<ForecastDay> GetWeatherAsync(string location, DateTime startDate, int duration)
        {
            var beginDate = startDate.ToString("yyyy/MM/dd");
            var endDate = startDate.AddDays(duration).ToString("yyyy/MM/dd");
            var request = new RestRequest(string.Format(ConfigurationManager.AppSettings["WeatherEndpoint"], location, beginDate, endDate), Method.GET);
            var response = await _client.ExecuteTaskAsync<ForecastDay>(request);
            return response.Data;
        }

    }
}
