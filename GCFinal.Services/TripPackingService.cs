using GCFinal.Data;
using GCFinal.Domain.Models;
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

        public void CreateTrip(Trip trip)
        {
            db.Trips.Add(trip);
        }

        public IQueryable<PackingItem> GetPackedItems()
        {
            int tripId = db.Trips.Max(x => x.Id);
            return db.PackingItems.Where(x => x.TripId == tripId);
        }

        public void PackItems(decimal tempAvg, decimal rainAvg, decimal windAvg, decimal duration)
        {
            var clothes = GetItemsToPack(tempAvg, rainAvg, windAvg);
            if (duration <= 7)
            {
                foreach (var cloth in clothes)
                {
                    if (cloth.IsBulk)
                    {
                        db.PackingItems.Add(new PackingItem(cloth.Weight, Math.Ceiling(duration / 3))
                        {
                            Name = cloth.Name,
                            Height = cloth.Height,
                            Length = cloth.Length,
                            Width = cloth.Width
                        });
                    }

                    if (cloth.IsDaily)
                    {
                        db.PackingItems.Add(new PackingItem(cloth.Weight, duration)
                        {
                            Name = cloth.Name,
                            Height = cloth.Height,
                            Length = cloth.Length,
                            Width = cloth.Width
                        });
                    }

                    if (cloth.IsEssential)
                    {
                        db.PackingItems.Add(new PackingItem(cloth.Weight, 1)
                        {
                            Name = cloth.Name,
                            Height = cloth.Height,
                            Length = cloth.Length,
                            Width = cloth.Width
                        });
                    }
                }
            }

            if (duration > 7)
            {
                foreach (var cloth in clothes)
                {
                    if (cloth.IsBulk)
                    {
                        db.PackingItems.Add(new PackingItem(cloth.Weight, 3)
                        {
                            Name = cloth.Name,
                            Height = cloth.Height,
                            Length = cloth.Length,
                            Width = cloth.Width
                        });
                    }

                    if (cloth.IsDaily)
                    {
                        db.PackingItems.Add(new PackingItem(cloth.Weight, 7)
                        {
                            Name = cloth.Name,
                            Height = cloth.Height,
                            Length = cloth.Length,
                            Width = cloth.Width
                        });
                    }

                    if (cloth.IsEssential)
                    {
                        db.PackingItems.Add(new PackingItem(cloth.Weight, 1)
                        {
                            Name = cloth.Name,
                            Height = cloth.Height,
                            Length = cloth.Length,
                            Width = cloth.Width
                        });
                    }
                }
            }
            db.SaveChanges();

        }

        public IQueryable<TripItem> GetItemsToPack(decimal tempAvg, decimal rainAvg, decimal windAvg)
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

        private IQueryable<TripItem> GetHotClothes(bool isRain)
        {
            if (isRain)
            {
                return db.Items.Where(x => x.Hot == true || x.IsRain == isRain);
            }
            else return db.Items.Where(x => x.Hot == true);
        }

        private IQueryable<TripItem> GetWarmClothes(bool isRain, bool isWind)
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

        private IQueryable<TripItem> GetCoolClothes(bool isRain, bool isWind)
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

        private IQueryable<TripItem> GetColdClothes()
        {
            return db.Items.Where(x => x.Cold == true);
        }

        public bool IsPrecipitating(decimal rainValue)
        {
            if (rainValue > 6)
            {
                return true;
            }
            return false;
        }

        public bool IsWindy(decimal windValue)
        {
            if (windValue > 15)
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
