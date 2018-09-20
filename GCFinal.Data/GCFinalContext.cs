using GCFinal.Data.Maps;
using GCFinal.Domain.Models;
using GCFinal.Domain.Models.Items;
using GCFinal.Domain.Models.PackingModels;
using System.Data.Entity;

namespace GCFinal.Data
{
    public class GCFinalContext : DbContext
    {
        public GCFinalContext() : base("GCFinalItems")
        {
            Database.SetInitializer(new GCFinalInitalizer());
        }

        public DbSet<TripItem> Items { get; set; }
        public DbSet<PackingItem> PackingItems { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ItemMap());
            modelBuilder.Configurations.Add(new PackingItemMap());
            modelBuilder.Configurations.Add(new TripMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
