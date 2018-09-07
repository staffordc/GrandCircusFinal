using GCFinal.Domain.Models;
using System;
using System.Threading.Tasks;

namespace GCFinal.Domain.Data
{
    public interface IWeatherService
    {
        Task<ForecastDay> GetWeatherAsync(string location, DateTime startDate, int duration);
    }
}
