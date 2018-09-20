using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCFinal.Domain.Models
{
    public class SuitcaseItem : Domain.Models.BinPackingModels.Item
    {
        public SuitcaseItem(string name, decimal dim1, decimal dim2, decimal dim3,int quantity) :base(name,dim1, dim2, dim3, quantity)
        {
            
        }

        public decimal Weight { get; set; }
    }
}
