using Microsoft.AspNetCore.Mvc;
using Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Controllers
{
    public class ShopController : Controller
    {
        private static ShopManager manager = new ShopManager();

        // for catalog
        public IActionResult Index()
        {
            List<Item> items = manager.GetAvailableItems();

            return View(items);
        }

        // for basket
        public IActionResult Basket()
        {
            return View();
        }
    }
}
