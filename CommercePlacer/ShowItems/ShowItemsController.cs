using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CommercePlacer.ShowItems
{
    public class ShowItemsController : Controller
    {
        public IActionResult Index()
        {

            TestDataGen.testStuff();
            return View();
        }
    }
}