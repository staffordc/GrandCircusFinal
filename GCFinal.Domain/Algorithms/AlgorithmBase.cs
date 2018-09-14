using GCFinal.Domain.Models.BinPackingModels;
using System.Collections.Generic;

namespace GCFinal.Domain.Algorithms
{
    public abstract class AlgorithmBase
    {
        public abstract ContainerPackingResult Run(Container container, List<Item> items);
    }
}
