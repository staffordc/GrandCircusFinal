using GCFinal.Domain.Models.BinPackingModels;
using System.Collections.Generic;
using System.Linq;

namespace GCFinal.Domain.Models
{
    public class SuitcasePackingResult
    {
        private IEnumerable<ContainerPackingResult> items;

        public Container Suitcase { get; set; }

        public IEnumerable<ContainerPackingResult> Items
        {
            get => items ?? Enumerable.Empty<ContainerPackingResult>();
            set => items = value;
        }

        public decimal GetTotalWeight()
        {
            //TODO add Null checks
            return Suitcase.Weight + Items.Sum(x => x.Weight);
        }
    }
}
