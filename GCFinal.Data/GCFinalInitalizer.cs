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
            context.Clothes.Add(new Clothing()
            {
                ItemName = "Shirt",
                FoldType = "Square",
                Length = 13M,
                Width = 10M,
                Height = 0.326M,
                Weight = 8.5M
            });

            context.Clothes.Add(new Clothing()
            {
                ItemName = "Shirt",
                FoldType = "Rectangle",
                Length = 6.65M,
                Width = 10M,
                Height = 0.715M,
                Weight = 8.5M
            });
            
            context.Clothes.Add(new Clothing()
            {
                ItemName = "Pants",
                FoldType = "Rectangle",
                Length = 19M,
                Width = 11M,
                Height = 0.92M,
                Weight = 22.9M
            });

            context.Clothes.Add(new Clothing(){
                ItemName = "Pants",
                FoldType = "Square",
                Length = 10.5M,
                Width = 11M,
                Height = 1.62M,
                Weight = 22.9M
            });

            context.Clothes.Add(new Clothing()
            {
                ItemName = "Sweater",
                FoldType  = "Square",
                Length = 10M,
                Width = 11.5M,
                Height = 1.7M,
                Weight = 14M
            });

            context.Clothes.Add(new Clothing()
            {
                ItemName = "Hoodie",
                FoldType = "Square",
                Length = 12M,
                Width = 11M,
                Height = 2.675M,
                Weight = 32M

            });

            context.Clothes.Add(new Clothing()
            {
                ItemName = "Short Socks",
                FoldType = "Rectangle",
                Length = 9M,
                Width = 3.5M,
                Height = .44M,
                Weight = 1.2M
            });

            context.Clothes.Add(new Clothing()
            {
                ItemName = "Tall Socks",
                FoldType = "Rectangle",
                Length = 9M,
                Width = 3.5M,
                Height = 0.72M,
                Weight = 1.68M
            });

            context.Clothes.Add(new Clothing()
            {
                ItemName = "Undergarments",
                FoldType = "Rectangle",
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
