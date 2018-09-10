using GCFinal.Domain.Models.PackingModels;
using System.Collections.Generic;

namespace GCFinal.Domain.Data
{
    public interface IPackingService
    {
        IEnumerable<PackingItem> GetItems(IEnumerable<DayInfo> days);
    }
}

