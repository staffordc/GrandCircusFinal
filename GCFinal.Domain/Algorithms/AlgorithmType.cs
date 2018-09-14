using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCFinal.Domain.Algorithms
{
    [DataContract]
    public enum AlgorithmType
    {
        [DataMember]
        EB_AFIT = 1
    }
}
