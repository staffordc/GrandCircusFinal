using GCFinal.Data;
using GCFinal.Domain.Models.Items;
using GCFinal.Domain.Models.PackingModels;
using System;
using System.Linq;

namespace GCFinal.Services
{
    public class TripPackingService
    {
        private GCFinalContext db = new GCFinalContext();
        //Daily Items
        //Trip items

        public IQueryable<PackingItem> PackItems(decimal tempAvg, decimal rainAvg, decimal windAvg, decimal duration)
        {
            var clothes = GetItemsToPack(tempAvg, rainAvg, windAvg);
            if (duration <= 7)
            {
                foreach (var cloth in clothes)
                {
                    if (cloth.IsBulk)
                    {
                        db.PackingItems.Add(new PackingItem()
                        {
                            Name = cloth.Name,
                            Height = cloth.Height,
                            Length = cloth.Length,
                            Width = cloth.Width,
                            Weight = cloth.Weight,
                            Quantity = Math.Ceiling(duration / 3)
                        });
                    }

                    if (cloth.IsDaily)
                    {
                        db.PackingItems.Add(new PackingItem()
                        {
                            Name = cloth.Name,
                            Height = cloth.Height,
                            Length = cloth.Length,
                            Width = cloth.Width,
                            Weight = cloth.Weight,
                            Quantity = duration
                        });
                    }

                    if (cloth.IsEssential)
                    {
                        db.PackingItems.Add(new PackingItem()
                        {
                            Name = cloth.Name,
                            Height = cloth.Height,
                            Length = cloth.Length,
                            Width = cloth.Width,
                            Weight = cloth.Weight,
                            Quantity = 1
                        });
                    }
                }

                db.SaveChanges();
            }
        }


        public IQueryable<Item> GetItemsToPack(decimal tempAvg, decimal rainAvg, decimal windAvg)
        {
            var temperature = GetTempEnum(tempAvg);
            bool isPrecipitating = IsPrecipitating(rainAvg);
            bool isWindy = IsWindy(windAvg);
            switch (temperature)
            {
                case Temperature.Hot:
                    return GetHotClothes(isPrecipitating);

                case Temperature.Warm:
                    return GetWarmClothes(isPrecipitating, isWindy);

                case Temperature.Cool:
                    return GetCoolClothes(isPrecipitating, isWindy);

                case Temperature.Cold:
                    return GetColdClothes();

                default:
                    return GetColdClothes();
            }
        }

        private IQueryable<Item> GetHotClothes(bool isRain)
        {
            if (isRain)
            {
                return db.Items.Where(x => x.Hot == true || x.IsRain == isRain);
            }
            else return db.Items.Where(x => x.Hot == true);
        }

        private IQueryable<Item> GetWarmClothes(bool isRain, bool isWind)
        {
            if (isRain)
            {
                return db.Items.Where(x => x.Warm == true || x.IsRain == isRain);
            }

            if (isWind)
            {
                return db.Items.Where(x => x.Warm == true || x.IsWindy == isWind);
            }

            else return db.Items.Where(x => x.Warm == true);
        }

        private IQueryable<Item> GetCoolClothes(bool isRain, bool isWind)
        {
            if (isRain)
            {
                return db.Items.Where(x => x.Cool == true || x.IsRain == isRain);
            }

            if (isWind)
            {
                return db.Items.Where(x => x.Cool == true || x.IsWindy == isWind);
            }

            else return db.Items.Where(x => x.Cool == true);
        }

        private IQueryable<Item> GetColdClothes()
        {
            return db.Items.Where(x => x.Cold == true);
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
