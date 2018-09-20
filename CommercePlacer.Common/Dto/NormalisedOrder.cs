using CommercePlacer.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommercePlacer.Common.Dto
{
    public class NormalisedOrder : IOrder
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderItem> Items { get; set; }

        public NormalisedOrder(int orderId, DateTime orderDate, OrderStatus orderStatus, List<OrderItem> items) 
        {
            OrderId = orderId;
            OrderDate = orderDate;
            OrderStatus = OrderStatus;
            Items = items;
        }

        public double TotalCost
        {
            get { return Items.Sum(m => m.TotalCost); }
        }
    }
}
