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
        public List<OrderEntry> Entries { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime OrderStatusChanged { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public IEnumerable<DenormalisedOrder> toNormalisedOrder()
        {
            return Entries.Select(m => new DenormalisedOrder(Id, OrderPlaced, (Common.Model.OrderStatus)Enum.ToObject(typeof(Common.Model.OrderStatus), OrderStatus.Id),  m.ToDto()));
        }
    }
}
