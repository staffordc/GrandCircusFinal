using System.Runtime.Serialization;

namespace GCFinal.Domain.Algorithms
{
    [DataContract]
    public enum AlgorithmType
    {
        [DataMember]
        EB_AFIT = 1
    }
}
