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
        private IEntityRepository<OrderEntry> entryRepo;

        public OrderDetailsApi(IEntityRepository<Order> orderRepo, IEntityRepository<OrderEntry> entryRepo)
        {
            this.orderRepo = orderRepo;
            
            if (orderRepo is MockRepository<Order>)
            {
                TestDataGen.PopulateTestData(orderRepo, entryRepo);
            }
        }


        public IEnumerable<DenormalisedOrder> GetAllOrdersForReporting()
        {
            return orderRepo.getAll().SelectMany( m => m.ToDenormalisedOrder());
        }

        public NormalisedOrder GetOrderById(int orderId) => orderRepo.GetById(orderId).ToNormalisedOrder();

        public NormalisedOrder Save(NormalisedOrder order)
        {
            if (order.OrderId == 0)
            {
                Order toSave = new Order(order);
                return orderRepo.Insert(toSave).ToNormalisedOrder();
            }
            else
            {
                Order toSave = orderRepo.GetById(order.OrderId);
                toSave.OrderStatus = new OrderStatus
                {
                    Id = (int)order.OrderStatus
                };
                if (toSave.OrderPlaced == null)
                {
                    toSave.OrderPlaced = DateTime.Now;
                }
                return orderRepo.Update(toSave).ToNormalisedOrder();
            }
        }

        public OrderItem SaveEntry(OrderItem order)
        {
            var originalItem = entryRepo.GetById(order.OrderEntryId);
            originalItem.Quantity = order.Quantity;

            if (order.Quantity == 0)
            {
                entryRepo.DeleteById(order.OrderEntryId);

                return order;
            }
            
            entryRepo.Update(originalItem);
            return order;
        }
    }
}
