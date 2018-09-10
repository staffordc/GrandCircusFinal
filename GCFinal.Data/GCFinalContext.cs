using GCFinal.Data.Maps;
using GCFinal.Domain.Models.Items;
using System.Data.Entity;

namespace GCFinal.Data
{
    public class GCFinalContext : DbContext
    {
        public GCFinalContext() : base("GCFinalItems")
        {
            Database.SetInitializer(new GCFinalInitalizer());
        }

        public IDbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PackingMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
