using GCFinal.Domain.Models.PackingModels;

namespace GCFinal.Domain.Models.Items
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDaily { get; set; }

        // TODO: maybe have a "lookup" table for Slot that has the Id, Name, and IsRequiredForOutfit?
        public ItemSlot Slot { get; set; }

        // TODO: db should probably have a "lookup" table for the Temperture buckets/categories
        public Temperature Temperature { get; set; }

        public bool IsRain { get; set; }

        public bool IsWindy { get; set; }

        public decimal Weight { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        // TODO: how to tell if an item is for precipitation?

        // Maybe the original idea of 3 db tables was good...
        /*
         * Items
         * DailyItems (relates to items, includes additional columns for daily slot?)
         * TripItems (relates to items, includes columns that help define when it should be included like Temp or Precip...?)
         */
    }
}
