using GCFinal.Domain.Models.PackingModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace GCFinal.Data.Maps
{
    class PackingMap : EntityTypeConfiguration<PackingItem>
    {
        public PackingMap()
        {
           // HasKey(x => x.Id);
           // Property(x => x.Id).
           //     HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name);
            Property(x => x.Length);
            Property(x => x.Width);
            Property(x => x.Height);

        }
    }
}
