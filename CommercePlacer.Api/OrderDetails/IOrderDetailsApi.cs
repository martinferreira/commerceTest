﻿using CommercePlacer.Common.Dto;
using System.Collections.Generic;

namespace CommercePlacer.Api.OrderDetails
{
    public interface IOrderDetailsApi
    {
        IEnumerable<DenormalisedOrder> GetAllOrdersForReporting();
    }
}