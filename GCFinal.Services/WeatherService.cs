using GCFinal.Domain.Data;
using GCFinal.Domain.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
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

        public async Task<List<ForecastDay>> GetWeatherAsync(string location, DateTime startDate, int duration)
        {


            var beginDate = startDate.ToString("yyyy/MM/dd");
            var endDate = startDate.AddDays(duration - 1).ToString("yyyy/MM/dd");
            RestRequest request;
            
            if (startDate >= DateTime.Now)
            {
                request = new RestRequest(string.Format(ConfigurationManager.AppSettings["WeatherEndpointNow"], location, startDate, duration), Method.GET);
            }
            else
            {
                request = new RestRequest(string.Format(ConfigurationManager.AppSettings["WeatherEndpoint"], location, beginDate, endDate), Method.GET);
            }

            var response = await _client.ExecuteTaskAsync(request);
            var data = JsonConvert.DeserializeObject<RootObject>(response.Content);
            return data.Forecast.ForecastDay;

        }

    }
}
