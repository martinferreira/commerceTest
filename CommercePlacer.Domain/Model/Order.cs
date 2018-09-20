using CommercePlacer.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercePlacer.Domain.Model
{
    public class Order : EntityModel
    {
        public Order()
        {

        }

        public Order(NormalisedOrder order) : this()
        {
            Id = order.OrderId;
            OrderPlaced = order.OrderDate;
            OrderStatus = new OrderStatus
            {
                Id = (int)order.OrderStatus
            };
            Entries = order.Items.Select(m => new OrderEntry(m));
        }

        public IEnumerable<OrderEntry> Entries { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime OrderStatusChanged { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public IEnumerable<DenormalisedOrder> ToDenormalisedOrder()
        {
            return Entries.Select(m => 
                new DenormalisedOrder(
                    Id,
                    OrderPlaced, 
                    (Common.Model.OrderStatus)Enum.ToObject(typeof(Common.Model.OrderStatus), OrderStatus.Id), 
                m.ToDto()));
        }

        public NormalisedOrder ToNormalisedOrder()
        {
            return new NormalisedOrder(
                Id,
                OrderPlaced,
                (Common.Model.OrderStatus)Enum.ToObject(typeof(Common.Model.OrderStatus), OrderStatus.Id),
                Entries.Select(m => m.ToDto()).ToList()
                );
        }
    }
}
