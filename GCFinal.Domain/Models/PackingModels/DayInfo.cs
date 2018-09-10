using System;

namespace GCFinal.Domain.Models.PackingModels
{
    public class DayInfo
    {
        public DateTime Date { get; set; }

        public Temperature Temperature { get; set; }

        public bool IsPrecipitating { get; set; }
    }
}

