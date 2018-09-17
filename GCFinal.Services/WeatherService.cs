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
            if (startDate >= DateTime.Now.AddDays(+10))
            {//this should be a separate service that the controller is calling
                var beginDateNow = startDate.ToString("yyyy/MM/dd");
                var endDateNow = startDate.AddDays(duration - 1).ToString("yyyy/MM/dd");
                var requestNow = new RestRequest(string.Format(ConfigurationManager.AppSettings["WeatherEndpointNow"], location, beginDateNow, endDateNow), Method.GET);
                var responseNow = await _client.ExecuteTaskAsync(requestNow);
                var dataNow = JsonConvert.DeserializeObject<RootObject>(responseNow.Content);
                return dataNow.Forecast.ForecastDay;
            }
            else
            {
                var beginDate = startDate.ToString("yyyy/MM/dd");
                var endDate = startDate.AddDays(duration - 1).ToString("yyyy/MM/dd");
                var request = new RestRequest(string.Format(ConfigurationManager.AppSettings["WeatherEndpoint"], location, beginDate, endDate), Method.GET);

                var response = await _client.ExecuteTaskAsync(request);

                var data = JsonConvert.DeserializeObject<RootObject>(response.Content);
                return data.Forecast.ForecastDay;
            }
        }

    }
}
