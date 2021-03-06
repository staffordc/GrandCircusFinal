﻿using GCFinal.Domain.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace GCFinal.MVC.Client
{
    public class WeatherClient
    {
        private readonly IRestClient _client;
        public WeatherClient()
        {
            _client = new RestClient(ConfigurationManager.AppSettings["WeatherApiBaseUrl"]);
        }
        public async Task<List<RootObject>> GetHistoricalWeather(string location, DateTime startDate, int duration)
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
                Type = ParameterType.QueryString,
                Value = duration
            });
            var response = await _client.ExecuteTaskAsync(request);

            //This assumes that we always have a valid API call from OUR API.  If not then we get the famous "line 40 JSON" error
            //TODO: check if(response.StatusCode == HttpStatusCode.OK) then return JsonConvert.  else...do stuff

            return JsonConvert.DeserializeObject<List<RootObject>>(response.Content);
        }

        public async Task<List<RootObject>> GetForecastWeather(string location, int duration)
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
                Name = "duration",
                Type = ParameterType.QueryString,
                Value = duration
            });

            var response = await _client.ExecuteTaskAsync(request);
            return JsonConvert.DeserializeObject<List<RootObject>>(response.Content);
        }
    }
}