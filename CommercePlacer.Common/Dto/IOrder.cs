using CommercePlacer.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercePlacer.Common.Dto
{
    public interface IOrder
    {
        int OrderId { get; set; }
        DateTime OrderDate { get; set; }
        OrderStatus OrderStatus { get; set; }
    }
}
