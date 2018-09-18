using GCFinal.Domain.Models.BinPackingModels;
using System.Collections.Generic;

namespace GCFinal.Domain.Data
{
    public interface IContainerService
    {
        IEnumerable<Container> GetContainers();
    }
}
