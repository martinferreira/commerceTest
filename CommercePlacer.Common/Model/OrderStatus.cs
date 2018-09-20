using System;
using System.Collections.Generic;
using System.Text;

namespace CommercePlacer.Common.Model
{
    public enum OrderStatus : byte
    {
        Placed = 1,
        OnRoute = 2,
        Delivered = 3,
        Returned = 4
    }
}
