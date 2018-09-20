using GCFinal.Domain.Models.BinPackingModels;
using System.Collections.Generic;
using System.Linq;

namespace GCFinal.Domain.Models
{
    public class SuitcasePackingResult
    {
        private IEnumerable<ContainerPackingResult> items;

        public Container Suitcase { get; set; }

        // TODO This is where we go off the rails and get 2 suitcases
        // need it so return suitcase weight and sum the item.totalWeight
        public IEnumerable<ContainerPackingResult> Items
        {
            get => items ?? Enumerable.Empty<ContainerPackingResult>();
            set => items = value;
        }

        public decimal GetTotalWeight()
        {
            //TODO add Null checks
            return Suitcase.Weight + Items.SelectMany(x =>x.AlgorithmPackingResults).SelectMany(x => x.PackedItems).Sum(x => x.Weight);
        }
    }
}
