using GCFinal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCFinal.Domain.Data
{
    public interface IWeatherService
    {
        Task<List<ForecastDay>> GetWeatherAsync(string location, DateTime startDate, int duration);
    }
}
