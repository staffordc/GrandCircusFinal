using GCFinal.Domain.Algorithms;
using GCFinal.Domain.Data;
using GCFinal.Domain.Models;
using GCFinal.Domain.Models.BinPackingModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GCFinal.Services
{
    public class SuitcasePackingService
    {
        private static readonly List<int> PackingAlgorithms = new List<int>
        {
            (int)AlgorithmType.EB_AFIT,
        };

        private readonly IContainerService containerService;

        public SuitcasePackingService(IContainerService containerService)
        {
            this.containerService = containerService ?? throw new ArgumentNullException(nameof(containerService));
        }

        public SuitcasePackingResult Pack(IEnumerable<SuitcaseItem> items)
        {
            var result = new SuitcasePackingResult();
            var containers = this.containerService.GetContainers().OrderBy(c => c.Volume);
            foreach (var container in containers)
            {
                var results = PackingService.Pack(new List<Container> { container, }, items.ToList(), PackingAlgorithms);
                if (!results.SelectMany(x => x.AlgorithmPackingResults).SelectMany(x => x.UnpackedItems).Any())
                {
                    result.Suitcase = container;
                    result.Items = results;
                    break;
                }
            }

            return result;
        }
    }
}
