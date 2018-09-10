using GCFinal.Domain.Models.Items;
using GCFinal.Domain.Models.PackingModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace GCFinal.Data.Maps
{
    class PackingMap : EntityTypeConfiguration<Item>
    {
        public PackingMap()
        {
            HasKey(x => x.Id).
            Property(x => x.Id).
               HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
