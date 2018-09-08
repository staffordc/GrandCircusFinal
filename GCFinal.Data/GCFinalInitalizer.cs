using GCFinal.Domain.Models.PackingModels;
using System.Data.Entity;

namespace GCFinal.Data
{
    public class GCFinalInitalizer : CreateDatabaseIfNotExists<GCFinalContext>
    {
        protected override void Seed(GCFinalContext context)
        {
            context.Clothes.Add(new Clothing()
            {
                ItemName = "Shirt", //rectangle fold
                Length = 13M,
                Width = 10M,
                Height = 0.326M
            });
            
            context.Clothes.Add(new Clothing()
            {
                ItemName = "Pants", //rectangle fold
                Length = 19M,
                Width = 11M,
                Height = 0.92M
            });

            context.Clothes.Add(new Clothing()
            {
                ItemName = "Sweater", //rectangle fold
                Length = 10M,
                Width = 11.5M,
                Height = 1.7M
            });

            context.Clothes.Add(new Clothing()
            {
                ItemName = "Hoodie", //rectangle fold
                Length = 12M,
                Width = 11M,
                Height = 2.675M
            });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
