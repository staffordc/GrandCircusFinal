using GCFinal.Domain.Models.PackingModels;
using System;
using System.Collections.Generic;

namespace GCFinal.Domain.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public virtual ICollection<PackingItem> PackingItems { get; set; }
    }
}
