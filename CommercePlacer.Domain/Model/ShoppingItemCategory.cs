using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercePlacer.Domain.Model
{
    public class ShoppingItemCategory : EntityModel
    {
        public ShoppingItemCategory Parent { get; set; }
        public string Description { get;  set; }
    }
}
