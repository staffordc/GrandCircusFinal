﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GCFinal.Domain.Models;
using RestSharp;
using Newtonsoft.Json;

namespace GCFinal.MVC.Client
{
    public class WeatherClient
    {
        private readonly IRestClient _client;
        public WeatherClient()
        {
            _client = new RestClient(ConfigurationManager.AppSettings["WeatherApiBaseUrl"]);
        }
        public async Task<List<ForecastDay>> GetHistoricalWeather(string location, DateTime startDate, int duration)
        {
            var request = new RestRequest("api/weather", Method.GET);
            request.Parameters.Add(new Parameter()
            {
                Name = "location",
                Type = ParameterType.QueryString,
                Value = location
            });
            request.Parameters.Add(new Parameter()
            {
                Name = "startDate",
                Type = ParameterType.QueryString,
                Value = startDate
            });
            request.Parameters.Add(new Parameter()
            {
                Name = "duration",
                Type =ParameterType.QueryString,
                Value = duration
            });
            var response = await _client.ExecuteTaskAsync(request);
            return JsonConvert.DeserializeObject<List<ForecastDay>>(response.Content);
        }
    }
}