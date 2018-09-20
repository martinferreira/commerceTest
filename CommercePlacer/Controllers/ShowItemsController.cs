using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommercePlacer.Api;
using CommercePlacer.Api.OrderDetails;
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
    }
}