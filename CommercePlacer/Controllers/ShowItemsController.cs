using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommercePlacer.Api;
using Microsoft.AspNetCore.Mvc;

namespace CommercePlacer.ShowItems
{
    public class ShowItemsController : Controller
    {
        public IActionResult Index()
        {
            return View(TestDataGen.TestStuff());
        }
    }
}