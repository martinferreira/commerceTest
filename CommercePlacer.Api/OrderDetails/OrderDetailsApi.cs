using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommercePlacer.Common.Dto;
using CommercePlacer.Domain.Model;
using CommercePlacer.Domain.Repositories;

namespace CommercePlacer.Api.OrderDetails
{
    public class OrderDetailsApi : IOrderDetailsApi
    {
        private IEntityRepository<Order> orderRepo;

        public OrderDetailsApi(IEntityRepository<Order> orderRepo)
        {
            this.orderRepo = orderRepo;
            if (orderRepo is MockRepository<Order>)
            {
                TestDataGen.PopulateTestData(orderRepo);
            }
        }


        public IEnumerable<DenormalisedOrder> GetAllOrdersForReporting()
        {
            return orderRepo.getAll().SelectMany( m => m.toNormalisedOrder());
        }
    }
}
