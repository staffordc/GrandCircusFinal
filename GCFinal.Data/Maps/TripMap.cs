using GCFinal.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GCFinal.Data.Maps
{
    public class TripMap : EntityTypeConfiguration<Trip>
    {
        public TripMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(x => x.PackingItems).WithRequired(x => x.Trip).HasForeignKey(x => x.TripId);

        }
    }
}
