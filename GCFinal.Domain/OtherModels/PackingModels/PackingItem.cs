namespace GCFinal.Domain.Models.PackingModels
{
    public class PackingItem
    {
        public PackingItem()
        {
            
        }

        public PackingItem(decimal weight, decimal quantity)
        {
            Weight = weight;
            Quantity = quantity;
            TotalWeight = weight * quantity;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Weight { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public decimal Quantity { get; set; }

        public decimal TotalWeight { get; set; }

    }
}
