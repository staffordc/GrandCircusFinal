using GCFinal.Domain.Models.Items;
using System.Data.Entity;

namespace GCFinal.Data
{
    public class GCFinalInitalizer : DropCreateDatabaseAlways<GCFinalContext>
    {
        protected override void Seed(GCFinalContext context)
        {
            //Length, Width and Height are Inches
            //Weight is Ounces
            context.Items.Add(new TripItem()
            {
                Name = "Short Sleeve Shirt",
                Hot = true,
                Warm = true,
                Cool = false,
                Cold = false,
                IsRain = false,
                IsWindy = false,
                IsDaily = true,
                IsBulk = false,
                IsEssential = false,
                Length = 13M,
                Width = 10M,
                Height = 0.326M,
                Weight = 8.5M
            });

            context.Items.Add(new TripItem()
            {
                Name = "Long Sleeve Shirt",
                Hot = false,
                Warm = false,
                Cool = true,
                Cold = true,
                IsRain = false,
                IsWindy = false,
                IsDaily = true,
                IsBulk = false,
                IsEssential = false,
                Length = 13M,
                Width = 10M,
                Height = 0.326M,
                Weight = 8.5M
            });

            context.Items.Add(new TripItem()
            {
                Name = "Shorts/Skirts",
                Hot = true,
                Warm = false,
                Cool = false,
                Cold = false,
                IsRain = false,
                IsWindy = false,
                IsDaily = false,
                IsBulk = true,
                IsEssential = false,
                Length = 10.5M,
                Width = 11M,
                Height = 0.92M,
                Weight = 16.9M
            });

            context.Items.Add(new TripItem()
            {
                Name = "Pants/Jeans",
                Hot = false,
                Warm = true,
                Cool = true,
                Cold = true,
                IsRain = false,
                IsWindy = false,
                IsDaily = false,
                IsBulk = true,
                IsEssential = false,
                Length = 10.5M,
                Width = 11M,
                Height = 1.62M,
                Weight = 22.9M
            });

            context.Items.Add(new TripItem()
            {
                Name = "Sweater",
                Hot = false,
                Warm = false,
                Cool = true,
                Cold = true,
                IsRain = false,
                IsWindy = false,
                IsDaily = false,
                IsBulk = true,
                IsEssential = false,
                Length = 10M,
                Width = 11.5M,
                Height = 1.7M,
                Weight = 14M
            });

            context.Items.Add(new TripItem()
            {
                Name = "Hoodie",
                Hot = false,
                Warm = false,
                Cool = true,
                Cold = true,
                IsRain = false,
                IsWindy = false,
                IsDaily = false,
                IsBulk = false,
                IsEssential = true,
                Length = 10M,
                Width = 11.5M,
                Height = 1.7M,
                Weight = 23M
            });

            context.Items.Add(new TripItem()
            {
                Name = "Socks",
                Hot = true,
                Warm = true,
                Cool = true,
                Cold = true,
                IsRain = false,
                IsWindy = false,
                IsDaily = true,
                IsBulk = false,
                IsEssential = false,
                Length = 9M,
                Width = 3.5M,
                Height = 0.72M,
                Weight = 1.68M
            });

            context.Items.Add(new TripItem()
            {
                Name = "Underwear",
                Hot = true,
                Warm = true,
                Cool = true,
                Cold = true,
                IsRain = false,
                IsWindy = false,
                IsDaily = true,
                IsBulk = false,
                IsEssential = false,
                Length = 4.5M,
                Width = 7.7M,
                Height = .45M,
                Weight = 2.46M
            });

            context.Items.Add(new TripItem()
            {
                Name = "Undershirt/Bra",
                Hot = true,
                Warm = true,
                Cool = true,
                Cold = true,
                IsRain = false,
                IsWindy = false,
                IsDaily = true,
                IsBulk = false,
                IsEssential = false,
                Length = 4.5M,
                Width = 7.7M,
                Height = .45M,
                Weight = 2.46M
            });

            context.Items.Add(new TripItem()
            {
                Name = "Jacket",
                Hot = false,
                Warm = false,
                Cool = false,
                Cold = true,
                IsRain = false,
                IsWindy = false,
                IsDaily = false,
                IsBulk = false,
                IsEssential = true,
                Length = 12M,
                Width = 11M,
                Height = 2.675M,
                Weight = 32M
            });

            context.Items.Add(new TripItem()
            {
                Name = "Gloves",
                Hot = false,
                Warm = false,
                Cool = false,
                Cold = true,
                IsRain = false,
                IsWindy = false,
                IsDaily = false,
                IsBulk = false,
                IsEssential = true,
                Length = 9M,
                Width = 3.5M,
                Height = 0.72M,
                Weight = 1.68M
            });

            context.Items.Add(new TripItem()
            {
                Name = "Hat",
                Hot = false,
                Warm = false,
                Cool = false,
                Cold = true,
                IsRain = false,
                IsWindy = false,
                IsDaily = false,
                IsBulk = false,
                IsEssential = true,
                Length = 9M,
                Width = 3.5M,
                Height = 0.72M,
                Weight = 1.68M
            });

            context.Items.Add(new TripItem()
            {
                Name = "Scarf",
                Hot = false,
                Warm = false,
                Cool = false,
                Cold = true,
                IsRain = false,
                IsWindy = false,
                IsDaily = false,
                IsBulk = false,
                IsEssential = true,
                Length = 9M,
                Width = 3.5M,
                Height = 0.72M,
                Weight = 1.68M
            });

            context.Items.Add(new TripItem()
            {
                Name = "Raincoat",
                Hot = false,
                Warm = false,
                Cool = false,
                Cold = false,
                IsRain = true,
                IsWindy = false,
                IsDaily = false,
                IsBulk = false,
                IsEssential = true,
                Length = 10M,
                Width = 11.5M,
                Height = 1.7M,
                Weight = 8M
            });

            context.Items.Add(new TripItem()
            {
                Name = "Umbrella",
                Hot = false,
                Warm = false,
                Cool = false,
                Cold = false,
                IsRain = true,
                IsWindy = false,
                IsDaily = false,
                IsBulk = false,
                IsEssential = true,
                Length = 9M,
                Width = 2.5M,
                Height = 2.5M,
                Weight = 10M
            });

            context.Items.Add(new TripItem()
            {
                Name = "Shoes",
                Hot = true,
                Warm = true,
                Cool = true,
                Cold = true,
                IsRain = false,
                IsWindy = false,
                IsDaily = false,
                IsBulk = false,
                IsEssential = true,
                Length = 11M,
                Width = 4M,
                Height = 4M,
                Weight = 12M
            });

            context.Items.Add(new TripItem()
            {
                Name = "Toiletries Bag",
                Hot = true,
                Warm = true,
                Cool = true,
                Cold = true,
                IsRain = false,
                IsWindy = false,
                IsDaily = false,
                IsBulk = false,
                IsEssential = true,
                Length = 9M,
                Width = 4M,
                Height = 4M,
                Weight = 13M
            });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
