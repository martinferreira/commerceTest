using CommercePlacer.Api.OrderDetails;
using CommercePlacer.Common.Dto;
using CommercePlacer.Domain.Model;
using CommercePlacer.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CommercePlacer.Api
{
    public static class TestDataGen
    {
        public static List<DenormalisedOrder> TestStuff()
        {
            IEntityRepository<Order> repo = new MockRepository<Order>();
            PopulateTestData(repo);
            IOrderDetailsApi api = new OrderDetailsApi(repo);
            return api.GetAllOrdersForReporting().ToList();

        }

        private static void PopulateTestData(IEntityRepository<Order> repo)
        {
            for (int rows = 0; rows < 10; rows++)
            {
                Order order = new Order
                {
                    OrderPlaced = DateTime.Now,
                    OrderStatusChanged = DateTime.Now,
                    OrderStatus = new OrderStatus()
                };
                order.OrderStatus.Description = Common.Model.OrderStatus.OnRoute.ToString();
                order.OrderStatus.Id =  (int) Common.Model.OrderStatus.OnRoute;

                for (int entries = 0; entries < new Random().Next(5)+1; entries++)
                {
                    OrderEntry newEntry = new OrderEntry
                    {
                        Item = new ShoppingItem
                        {
                            Category = new ShoppingItemCategory(),
                            Description = "Mock Item"
                        },
                        Quantity = new Random().Next(5) + 1
                    };
                    newEntry.Item.Category.Description = "Mock Category";

                    order.Entries.Add(newEntry);

                }
                repo.Insert(order);
            }
        }
    }
}
