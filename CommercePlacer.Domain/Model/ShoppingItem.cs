using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercePlacer.Domain.Model
{
    public class ShoppingItem : EntityModel
    {
        public ShoppingItem()
        {

        }

        public ShoppingItem(int orderEntryId, int itemCategoryId, string itemCategoryDescription, double price) : this()
        {
            this.Id = orderEntryId;
            Category = new ShoppingItemCategory
            {
                Id = itemCategoryId,
                Description = itemCategoryDescription
            };
            Price = price;
        }

        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public ShoppingItemCategory Category { get; set; }
    }
}
