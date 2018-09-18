using GCFinal.Domain.Data;
using GCFinal.Domain.Models.BinPackingModels;
using System.Collections.Generic;

namespace GCFinal.Services
{
    public class ContainerService : IContainerService
    {
        private static readonly List<Container> containers = new List<Container>
        {
            new Container(1, "Carry-On", 104M, 20.5M, 15M, 8M), //samsonite 21" Spinner - 43.5 total
            new Container(2, "Medium Suitcase", 144.88M, 23M, 17M, 99M), //samsonite 27" Spinner (27M, 18.5M,9.5M) - 55 total
            new Container(3, "Large Suitcase", 145.6M, 29.5M, 20.5M, 11M), //62" (must be 62" and 50 lbs or less)
        };

        public IEnumerable<Container> GetContainers()
        {
            return containers;
        }
    }
}
