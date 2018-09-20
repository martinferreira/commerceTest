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
            return orderRepo.getAll().SelectMany( m => m.ToDenormalisedOrder());
        }

        public NormalisedOrder GetOrderById(int orderId) => orderRepo.GetById(orderId).ToNormalisedOrder();

        public NormalisedOrder Save(NormalisedOrder order)
        {
            Order toSave = new Order(order);

            if (order.OrderId == 0)
            {
                return orderRepo.Insert(toSave).ToNormalisedOrder();
            }
            else
            {
                if (toSave.OrderPlaced == null)
                {
                    toSave.OrderPlaced = DateTime.Now();
                }
                return orderRepo.Update(toSave).ToNormalisedOrder();
            }
        }
    }
}
