using System;
using System.Collections.Generic;
using System.Text;

namespace CommercePlacer.Common.Dto
{
    public class OrderItem
    {
        public int ShoppingItemId { get; set; }
        public int OrderEntryId { get; set; }
        public string Description { get; set; }
        public int ItemCategoryId { get; set; }
        public string ItemCategoryDescription { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalCost
        {
            get { return Quantity * Price; }
        }

        public OrderItem(int id, int orderEntryId, string description, int category, string categoryDescription, double price, int quantity)
        {
            ShoppingItemId = id;
            OrderEntryId = orderEntryId;
            Description = description;
            ItemCategoryId = category;
            ItemCategoryDescription = categoryDescription;
            Price = price;
            Quantity = quantity;

        }

    }
}
