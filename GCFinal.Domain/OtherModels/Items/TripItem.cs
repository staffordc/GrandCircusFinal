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

    }
}
