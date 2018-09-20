using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GCFinal.Domain.Models.BinPackingModels
{
    [DataContract]
    public class AlgorithmPackingResult
    {
        public AlgorithmPackingResult()
        {
            this.PackedItems = new List<Item>();
            this.UnpackedItems = new List<Item>();
        }

        [DataMember]
        public int AlgorithmID { get; set; }

        [DataMember]
        public string AlgorithmName { get; set; }

        [DataMember]
        public bool IsCompletePack { get; set; }

        [DataMember]
        public List<Item> PackedItems { get; set; }

        [DataMember]
        public long PackTimeInMilliseconds { get; set; }

        [DataMember]
        public decimal PercentContainerVolumePacked { get; set; }

        [DataMember]
        public decimal PercentItemVolumePacked { get; set; }

        [DataMember]
        public List<Item> UnpackedItems { get; set; }
    }
}
