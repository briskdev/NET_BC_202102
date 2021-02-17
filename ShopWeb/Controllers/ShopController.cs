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
            List<Item> items = manager.Pay();

            return View(items);
        }

        // to buy item
        public IActionResult Buy(string name)
        {
            manager.AddToBasket(name);

            // send back to item catalog
            return RedirectToAction(nameof(Index));
        }
    }
}
