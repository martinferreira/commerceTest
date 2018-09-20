using CommercePlacer.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercePlacer.Domain.Model
{
    public class OrderEntry : EntityModel
    {
        public ShoppingItem Item { get; set; }
        public int Quantity { get; set; }

        public OrderItem ToDto()
        {
            return new OrderItem(Id, Item.Id, Item.Description, Item.Category.Id, Item.Category.Description, Item.Price, Quantity);
        }
    }
}
