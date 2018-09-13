using GCFinal.Domain.Models.PackingModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GCFinal.Data.Maps
{
    class PackingItemMap : EntityTypeConfiguration<PackingItem>
    {
        public PackingItemMap()
        {
            HasKey(x => x.Id).
                Property(x => x.Id).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
