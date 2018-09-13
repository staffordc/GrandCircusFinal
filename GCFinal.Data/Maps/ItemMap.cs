using GCFinal.Domain.Models.Items;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace GCFinal.Data.Maps
{
    class ItemMap : EntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            HasKey(x => x.Id).
            Property(x => x.Id).
               HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
