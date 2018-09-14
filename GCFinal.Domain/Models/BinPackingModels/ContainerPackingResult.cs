using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GCFinal.Domain.Models.BinPackingModels
{
    [DataContract]
    public class ContainerPackingResult
    {
        public ContainerPackingResult()
        {
            this.AlgorithmPackingResults = new List<AlgorithmPackingResult>();
        }

        [DataMember]
        public int ContainerID { get; set; }

        [DataMember]
        public List<AlgorithmPackingResult> AlgorithmPackingResults { get; set; }
    }
}
