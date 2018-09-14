using System.Runtime.Serialization;

namespace GCFinal.Domain.Models.BinPackingModels
{
    [DataContract]
    public class Item
    {
        private decimal volume;

        public Item(int id, decimal dim1, decimal dim2, decimal dim3, int quantity)
        {
            this.ID = id;
            this.Dim1 = dim1;
            this.Dim2 = dim2;
            this.Dim3 = dim3;
            this.volume = dim1 * dim2 * dim3;
            this.Quantity = quantity;
        }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public bool IsPacked { get; set; }

        [DataMember]
        public decimal Dim1 { get; set; }

        [DataMember]
        public decimal Dim2 { get; set; }

        [DataMember]
        public decimal Dim3 { get; set; }

        [DataMember]
        public decimal CoordX { get; set; }

        [DataMember]
        public decimal CoordY { get; set; }

        [DataMember]
        public decimal CoordZ { get; set; }

        public int Quantity { get; set; }

        [DataMember]
        public decimal PackDimX { get; set; }

        [DataMember]
        public decimal PackDimY { get; set; }

        [DataMember]
        public decimal PackDimZ { get; set; }

        [DataMember]
        public decimal Volume
        {
            get
            {
                return volume;
            }
        }
    }
}
