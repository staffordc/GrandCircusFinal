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
                IsDaily = true,
                Slot = ItemSlot.Top,
                Temperature = Temperature.Hot,
                Length = 13M,
                Width = 10M,
                Height = 0.326M,
                Weight = 8.5M
            });

            context.Items.Add(new Item()
            {
                Name = "Long Sleeve Shirt",
                IsDaily = true,
                Slot = ItemSlot.Top,
                Temperature = Temperature.Mild,
                Length = 13M,
                Width = 10M,
                Height = 0.326M,
                Weight = 8.5M
            });
            
            context.Items.Add(new Item()
            {
                Name = "Shorts",
                IsDaily = true,
                Slot = ItemSlot.Bottom,
                Temperature = Temperature.Hot,
                Length = 10.5M,
                Width = 11M,
                Height = 0.92M,
                Weight = 16.9M
            });

            context.Items.Add(new Item()
            {
                Name = "Pants",
                IsDaily = true,
                Slot = ItemSlot.Bottom,
                Temperature = Temperature.Mild,
                Length = 10.5M,
                Width = 11M,
                Height = 1.62M,
                Weight = 22.9M
            });

            context.Items.Add(new Item()
            {
                Name = "Sweater",
                IsDaily = true,
                Slot = ItemSlot.TopOuter,
                Temperature = Temperature.Cold,
                Length = 10M,
                Width = 11.5M,
                Height = 1.7M,
                Weight = 14M
            });

            context.Items.Add(new Item()
            {
                Name = "Hoodie",
                IsDaily = true,
                Slot = ItemSlot.TopOuter,
                Temperature = Temperature.Cool,
                Length = 12M,
                Width = 11M,
                Height = 2.675M,
                Weight = 32M

            });

            context.Items.Add(new Item()
            {
                Name = "Socks",
                IsDaily = true,
                Slot = ItemSlot.FeetInner,
                Temperature = Temperature.Mild,
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
                Temperature = Temperature.Mild,
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
                Temperature = Temperature.Mild,
                Length = 4.5M,
                Width = 7.7M,
                Height = .45M,
                Weight = 2.46M
            });

<<<<<<< HEAD
            context.Items.Add(new Item()
            {
                Name = "Jacket",
                IsDaily = false,
                Slot = ItemSlot.TopExterior,
                Temperature = Temperature.Cold,
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
                Temperature = Temperature.Mild,
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
                Temperature = Temperature.Mild,
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
                Temperature = Temperature.Mild,
                Length = 11M,
                Width = 4M,
                Height = 4M,
                Weight = 12M
            });

            context.Items.Add(new Item()
            {
                Name = "Toiletries Bag",
                IsDaily = false,
                Slot = ItemSlot.Accessory,
                Temperature = Temperature.Mild,
                Length = 9M,
                Width = 4M,
                Height = 4M,
                Weight = 13M
            });
            
=======
>>>>>>> feature/APIData
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
