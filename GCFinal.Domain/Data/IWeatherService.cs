using GCFinal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCFinal.Domain.Data
{
    public interface IWeatherService
    {
        Task<RootObject> GetHistoricalAsync(string location, DateTime startDate, int duration);
        Task<RootObject> GetForecastAsync(string location, int duration);
    }
}
