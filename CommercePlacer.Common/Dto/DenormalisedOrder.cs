using CommercePlacer.Common.Model;
using System;


namespace CommercePlacer.Common.Dto
{
    public class DenormalisedOrder : OrderItem, IOrder
    {
        public int OrderId { get ; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public DenormalisedOrder(int orderId, DateTime orderDate, OrderStatus orderStatus, int itemId, int orderEntryId,
                                string description, int category, string categoryDescription, double price, int quantity) : 
            base(itemId,  orderEntryId, description,  category,  categoryDescription,  price, quantity)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            OrderStatus = OrderStatus;
        }
  
        public DenormalisedOrder(int orderId, DateTime orderDate, OrderStatus orderStatus, OrderItem item) : 
            this(orderId,orderDate, orderStatus, 
                item.ShoppingItemId, item.OrderEntryId, item.Description,item.ItemCategoryId,item.ItemCategoryDescription,item.Price, item.Quantity)
        {
            //Nothing more to do
        }
    }
}
