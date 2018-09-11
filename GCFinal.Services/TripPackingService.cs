using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCFinal.Domain.Data;
using GCFinal.Domain.Models.PackingModels;
using GCFinal.Domain.Models.Items;
using GCFinal.Data;

namespace GCFinal.Services
{
    class TripPackingService
    {
        private GCFinalContext db = new GCFinalContext();
        //Daily Items
        //Trip items

        public IQueryable ItemsToPack( decimal tempAvg, decimal rainAvg, decimal windAvg)
        {
            var temperature = GetTempEnum(tempAvg);
            bool isPrecipitating = IsPrecipitating(rainAvg);
            bool isWindy = IsWindy(windAvg);
            switch (temperature)
            {
                case Temperature.Hot:
                    return GetHotClothes(temperature, isPrecipitating);

                case Temperature.Warm:
                    return GetWarmClothes(temperature, isPrecipitating, isWindy);

                case Temperature.Cool:
                    return GetCoolClothes(temperature, isPrecipitating, isWindy);

                case Temperature.Cold:
                    return GetColdClothes(temperature);

                default:
                    return GetColdClothes(temperature);
            }
        }

        private IQueryable GetHotClothes(Temperature hot, bool isRain)
        {
            if (isRain == true)
            {
                return db.Items.Where(x => x.Temperature == hot || x.IsRain == true); 
            }
            else return db.Items.Where(x => x.Temperature == hot);
        }

        private IQueryable GetWarmClothes(Temperature warm, bool isRain, bool isWind)
        {
            if (isRain == true)
            {
                return db.Items.Where(x => x.Temperature == warm || x.IsRain == true);
            }

            if (isWind == true)
            {
                return db.Items.Where(x => x.Temperature == warm || x.IsWindy == true);
            }

            else return db.Items.Where(x => x.Temperature == warm);
        }

        private IQueryable GetCoolClothes(Temperature cool, bool isRain, bool isWind)
        {
            if (isRain == true)
            {
                return db.Items.Where(x => x.Temperature == cool || x.IsRain == true);
            }

            if (isWind == true)
            {
                return db.Items.Where(x => x.Temperature == cool || x.IsWindy == true);
            }

            else return db.Items.Where(x => x.Temperature == cool);
        }

        private IQueryable GetColdClothes(Temperature cold)
        {
            return db.Items.Where(x => x.Temperature == cold);
        }

        public bool IsPrecipitating(decimal rainValue)
        {
            if (rainValue > 10)
            {
                return true;
            }
            return false;
        }

        public bool IsWindy(decimal windValue)
        {
            if (windValue > 10)
            {
                return true;
            }
            return false;
        }

        public Temperature GetTempEnum (decimal temp)
        {
            if (temp >= 80)
            {
                return Temperature.Hot;
            }

            if (temp >= 65 && temp < 79)
            {
                return Temperature.Warm;
            }

            if (temp >= 45 && temp < 64)
            {
                return Temperature.Cool;
            }
            
            return Temperature.Cold;
            
        }
    }
}
