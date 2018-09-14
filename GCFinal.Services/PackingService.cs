//using System;
//using System.Collections.Generic;
//using System.Linq;
//using GCFinal.Domain.Data;
//using GCFinal.Domain.Models.PackingModels;
//using GCFinal.Domain.Models.Items;

//namespace GCFinal.Services
//{
//    public class PackingService : IPackingService
//    {
//        // this defines a subset of slots that are used for picking daily outfits
//        private static readonly ISet<ItemSlot> SlotsForOutfits = new HashSet<ItemSlot>
//        {
//            ItemSlot.TopOuter,
//            ItemSlot.Top,
//            ItemSlot.TopInner,
//            ItemSlot.Bottom,
//            ItemSlot.BottomInner,
//            ItemSlot.FeetInner,
//            ItemSlot.Feet
//        };

//        private readonly IItemRepository itemRepository;

//        public PackingService(IItemRepository itemRepository)
//        {
//            this.itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
//        }


//        //returns all items to be packed
//        public IEnumerable<PackingItem> GetItems(IEnumerable<DayInfo> days)
//        {
//            var dailyItems = this.GetDailyItems(days);
//            var tripItems = this.GetTripItems(days);

//            return dailyItems.Concat(tripItems).ToList();
//        }


//        //logic to get clothing per day based on weather
//        public IEnumerable<PackingItem> GetDailyItems(IEnumerable<DayInfo> days)
//        {
//            var dailyItems = this.itemRepository.GetDailyItems();
//            var dailyItemsBySlot = dailyItems.ToLookup(k => k.Slot);
//            IList<PackingItem> itemsToPack = new List<PackingItem>();
//            foreach (var day in days)
//            {
//                foreach (var slot in SlotsForOutfits)
//                {
//                    // skip any slots that don't exist in the data - TODO this might be problematic!
//                    if (!dailyItemsBySlot.Contains(slot))
//                    {
//                        continue;
//                    }

//                    var itemsForSlot = dailyItemsBySlot[slot];
//                    var isSlotRequired = slot != ItemSlot.TopOuter; // TODO: metadata for slots IsRequired?
//                    var item = this.GetItemForSlot(itemsForSlot, day.Temperature, isSlotRequired);
//                    if (item != null)
//                    {
//                        itemsToPack.Add(item);
//                    }
//                    else if (isSlotRequired)
//                    {
//                        // TODO: we have reached an error condition - a required slot is null!
//                        // log, throw an exception, whatever makes sense for your application
//                    }
//                }
//            }

//            return itemsToPack;
//        }

//        public PackingItem GetItemForSlot(IEnumerable<TripItem> itemsForSlot, Temperature targetTemperature, bool isRequired)
//        {
//            // TODO: this algorithm is untested and a bit janky -I tried to work from the "most extreme" to mild, depending on whether the target temp was more on the warm or cold side.
//            // write your own way to "pick an item for a slot" based on the target temp
//            // suggested implementations:
//            // * target temp if exists, otherwise one step colder, or one step hotter, or 2 steps colder, or 2 steps hotter, etc.
//            // * start at the "hottest" or "coldest" available item and go up/down the list til you get the "closest" item
//            // * some other custom "how do I pick the most applicable piece?"
//            bool isColdFirst = targetTemperature <= Temperature.Mild;

//            TripItem chosen = null;
//            if (isColdFirst)
//            {
//                var sorted = itemsForSlot.OrderByDescending(i => i.Temperature);
//                foreach (var item in sorted)
//                {
//                    if (item.Temperature > targetTemperature)
//                    {
//                        continue;
//                    }

//                    if (!isRequired && item.Temperature > Temperature.Mild)
//                    {
//                        break;
//                    }

//                    chosen = item;
//                }
//            }
//            else
//            {
//                var sorted = itemsForSlot.OrderBy(i => i.Temperature);
//                foreach (var item in sorted)
//                {
//                    if (item.Temperature < targetTemperature)
//                    {
//                        continue;
//                    }

//                    if (!isRequired && item.Temperature <= Temperature.Mild)
//                    {
//                        break;
//                    }

//                    chosen = item;
//                }
//            }

//            return chosen != null
//                ? new PackingItem
//                {
//                    Name = chosen.Name,
//                    Weight = chosen.Weight,
//                    Length = chosen.Length,
//                    Width = chosen.Width,
//                    Height = chosen.Height,
//                }
//                : null;
//        }

//        public IEnumerable<PackingItem> GetTripItems(IEnumerable<DayInfo> days)
//        {
//            var tripItems = this.itemRepository.GetTripItems();
//            IList<PackingItem> itemsToPack = new List<PackingItem>();

//            // TODO: implement trip item selection here; afaik you just need to get the trip-level items for Temperature.Cold and any that are Precip == true

//            return itemsToPack;
//        }
//    }
//}