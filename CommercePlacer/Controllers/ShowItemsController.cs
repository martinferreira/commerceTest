using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommercePlacer.Api;
using CommercePlacer.Api.OrderDetails;
using CommercePlacer.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CommercePlacer.ShowItems
{
    public class ShowItemsController : Controller
    {
        private IOrderDetailsApi api;

        public ShowItemsController(IOrderDetailsApi api)
        {
            this.api = api;
        }

        public IActionResult Index()
        {
            return View(api.GetAllOrdersForReporting());
        }

        [HttpGet]
        public IActionResult ManageOrder(int? id)
        {
            if (id == null)
            {
                NormalisedOrder order = api.Save(new NormalisedOrder());
                return RedirectToAction("ManageOrder/" + order.OrderId);
            }
            return View(api.GetOrderById(id.Value));
        }
        [HttpPost]
        public IActionResult SaveOrder(NormalisedOrder order)
        {
            api.Save(order);
            return RedirectToAction("ManageOrder/" + order.OrderId);
        }

        [HttpPost]
        public IActionResult Save(OrderItem order)
        {
            return View(api.SaveEntry(order));
        }
    }
}