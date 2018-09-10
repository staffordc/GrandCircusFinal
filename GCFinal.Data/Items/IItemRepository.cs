using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCFinal.Data.Items
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetDailyItems();

        IEnumerable<Item> GetTripItems();
    }
}