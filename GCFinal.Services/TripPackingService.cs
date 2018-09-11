using GCFinal.Data;
using GCFinal.Domain.Models.PackingModels;
using System.Linq;

namespace GCFinal.Services
{
    public class TripPackingService
    {
        private GCFinalContext db = new GCFinalContext();
        //Daily Items
        //Trip items

        public IQueryable ItemsToPack(decimal tempAvg, decimal rainAvg, decimal windAvg)
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
            if (isRain)
            {
                return db.Items.Where(x => x.Temperature == hot || x.IsRain == isRain || x.IsDaily == true);
            }
            else return db.Items.Where(x => x.Temperature == hot || x.IsDaily == true);
        }

        private IQueryable GetWarmClothes(Temperature warm, bool isRain, bool isWind)
        {
            if (isRain)
            {
                return db.Items.Where(x => x.Temperature == warm || x.IsRain == isRain || x.IsDaily == true);
            }

            if (isWind)
            {
                return db.Items.Where(x => x.Temperature == warm || x.IsWindy == isWind || x.IsDaily == true);
            }

            else return db.Items.Where(x => x.Temperature == warm || x.IsDaily == true);
        }

        private IQueryable GetCoolClothes(Temperature cool, bool isRain, bool isWind)
        {
            if (isRain)
            {
                return db.Items.Where(x => x.Temperature == cool || x.IsRain == isRain || x.IsDaily == true);
            }

            if (isWind)
            {
                return db.Items.Where(x => x.Temperature == cool || x.IsWindy == isWind || x.IsDaily == true);
            }

            else return db.Items.Where(x => x.Temperature == cool || x.IsDaily == true);
        }

        private IQueryable GetColdClothes(Temperature cold)
        {
            return db.Items.Where(x => x.Temperature == cold || x.IsDaily == true);
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

        public Temperature GetTempEnum(decimal temp)
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
