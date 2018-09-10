using GCFinal.Domain.Models.PackingModels;
using System.Data.Entity;

namespace GCFinal.Data
{
    public class GCFinalInitalizer : CreateDatabaseIfNotExists<GCFinalContext>
    {
        protected override void Seed(GCFinalContext context)
        {
            //Length, Width and Height are Inches
            //Weight is Ounces
            context.PackingItems.Add(new PackingItem()
            {
                Name = "Shirt",
                Length = 13M,
                Width = 10M,
                Height = 0.326M,
                Weight = 8.5M
            });

            context.PackingItems.Add(new PackingItem()
            {
                Name = "Pants",
                Length = 10.5M,
                Width = 11M,
                Height = 1.62M,
                Weight = 22.9M
            });

            context.PackingItems.Add(new PackingItem()
            {
                Name = "Sweater",
                Length = 10M,
                Width = 11.5M,
                Height = 1.7M,
                Weight = 14M
            });

            context.PackingItems.Add(new PackingItem()
            {
                Name = "Hoodie",
                Length = 12M,
                Width = 11M,
                Height = 2.675M,
                Weight = 32M

            });

            context.PackingItems.Add(new PackingItem()
            {
                Name = "Socks",
                Length = 9M,
                Width = 3.5M,
                Height = 0.72M,
                Weight = 1.68M
            });

            context.PackingItems.Add(new PackingItem()
            {
                Name = "Undergarments",
                Length = 4.5M,
                Width = 7.7M,
                Height = .45M,
                Weight = 2.46M
            });
            
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
