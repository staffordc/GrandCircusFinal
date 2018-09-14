namespace GCFinal.Domain.Models.Items
{
    public class TripItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Hot { get; set; }

        public bool Warm { get; set; }

        public bool Cool { get; set; }

        public bool Cold { get; set; }

        public bool IsRain { get; set; }

        public bool IsWindy { get; set; }

        public bool IsDaily { get; set; }

        public bool IsEssential { get; set; }

        public bool IsBulk { get; set; }

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
