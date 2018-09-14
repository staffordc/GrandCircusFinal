using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCFinal.Domain.Models.Items
{
    public interface IItemRepository
    {
        IEnumerable<TripItem> GetDailyItems();

        IEnumerable<TripItem> GetTripItems();
    }
}