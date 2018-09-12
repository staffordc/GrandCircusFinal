using GCFinal.Domain.Models.Items;
using GCFinal.Domain.Models.PackingModels;
using System.Data.Entity;

namespace GCFinal.Data
{
    public class GCFinalInitalizer : DropCreateDatabaseAlways<GCFinalContext>
    {
        protected override void Seed(GCFinalContext context)
        {
            //Length, Width and Height are Inches
            //Weight is Ounces
            context.Items.Add(new Item()
            {
                Name = "Short Sleeve Shirt",
                IsDaily = false,
                Slot = ItemSlot.Top,
                Temperature = Temperature.Hot,
                Temperature2 = Temperature.Warm,
                IsRain = false,
                IsWindy = false,
                Length = 13M,
                Width = 10M,
                Height = 0.326M,
                Weight = 8.5M
            });

            context.Items.Add(new Item()
            {
                Name = "Long Sleeve Shirt",
                IsDaily = false,
                Slot = ItemSlot.Top,
                Temperature = Temperature.Warm,
                IsRain = false,
                IsWindy = false,
                Length = 13M,
                Width = 10M,
                Height = 0.326M,
                Weight = 8.5M
            });

            context.Items.Add(new Item()
            {
                Name = "Shorts",
                IsDaily = false,
                Slot = ItemSlot.Bottom,
                Temperature = Temperature.Hot,
                IsRain = false,
                IsWindy = false,
                Length = 10.5M,
                Width = 11M,
                Height = 0.92M,
                Weight = 16.9M
            });

            context.Items.Add(new Item()
            {
                Name = "Pants",
                IsDaily = false,
                Slot = ItemSlot.Bottom,
                Temperature = Temperature.Warm,
                Temperature2 = Temperature.Cool,
                Temperature3 = Temperature.Cold,
                IsRain = false,
                IsWindy = false,
                Length = 10.5M,
                Width = 11M,
                Height = 1.62M,
                Weight = 22.9M
            });

            context.Items.Add(new Item()
            {
                Name = "Sweater/Hoodie",
                IsDaily = false,
                Slot = ItemSlot.TopOuter,
                Temperature = Temperature.Cold,
                IsRain = false,
                IsWindy = false,
                Length = 10M,
                Width = 11.5M,
                Height = 1.7M,
                Weight = 20M
            });

            context.Items.Add(new Item()
            {
                Name = "Socks",
                IsDaily = true,
                Slot = ItemSlot.FeetInner,
                Temperature = null,
                IsRain = false,
                IsWindy = false,
                Length = 9M,
                Width = 3.5M,
                Height = 0.72M,
                Weight = 1.68M
            });

            context.Items.Add(new Item()
            {
                Name = "Bottom Undergarment",
                IsDaily = true,
                Slot = ItemSlot.BottomInner,
                Temperature = null,
                IsRain = false,
                IsWindy = false,
                Length = 4.5M,
                Width = 7.7M,
                Height = .45M,
                Weight = 2.46M
            });

            context.Items.Add(new Item()
            {
                Name = "Top Undergarment",
                IsDaily = true,
                Slot = ItemSlot.TopInner,
                Temperature = null,
                IsRain = false,
                IsWindy = false,
                Length = 4.5M,
                Width = 7.7M,
                Height = .45M,
                Weight = 2.46M
            });

            context.Items.Add(new Item()
            {
                Name = "Jacket",
                IsDaily = false,
                Slot = ItemSlot.TopExterior,
                Temperature = Temperature.Cold,
                IsRain = false,
                IsWindy = false,
                Length = 12M,
                Width = 11M,
                Height = 2.675M,
                Weight = 32M
            });

            context.Items.Add(new Item()
            {
                Name = "Gloves",
                IsDaily = false,
                Slot = ItemSlot.Hands,
                Temperature = Temperature.Cold,
                IsRain = false,
                IsWindy = false,
                Length = 9M,
                Width = 3.5M,
                Height = 0.72M,
                Weight = 1.68M
            });

            context.Items.Add(new Item()
            {
                Name = "Hat",
                IsDaily = false,
                Slot = ItemSlot.Head,
                Temperature = Temperature.Cold,
                IsRain = false,
                IsWindy = false,
                Length = 9M,
                Width = 3.5M,
                Height = 0.72M,
                Weight = 1.68M
            });

            context.Items.Add(new Item()
            {
                Name = "Scarf",
                IsDaily = false,
                Slot = ItemSlot.Accessory,
                Temperature = Temperature.Cold,
                IsRain = false,
                IsWindy = false,
                Length = 9M,
                Width = 3.5M,
                Height = 0.72M,
                Weight = 1.68M
            });

            context.Items.Add(new Item()
            {
                Name = "Raincoat",
                IsDaily = false,
                Slot = ItemSlot.TopExterior,
                Temperature = null,
                IsRain = true,
                IsWindy = true,
                Length = 10M,
                Width = 11.5M,
                Height = 1.7M,
                Weight = 8M
            });

            context.Items.Add(new Item()
            {
                Name = "Umbrella",
                IsDaily = false,
                Slot = ItemSlot.Accessory,
                Temperature = null,
                IsRain = true,
                IsWindy = false,
                Length = 9M,
                Width = 2.5M,
                Height = 2.5M,
                Weight = 10M
            });

            context.Items.Add(new Item()
            {
                Name = "Shoes",
                IsDaily = false,
                Slot = ItemSlot.Feet,
                Temperature = null,
                IsRain = false,
                Length = 11M,
                Width = 4M,
                Height = 4M,
                Weight = 12M
            });

            context.Items.Add(new Item()
            {
                Name = "Toiletries Bag",
                IsDaily = true,
                Slot = ItemSlot.Accessory,
                Temperature = null,
                IsRain = false,
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
