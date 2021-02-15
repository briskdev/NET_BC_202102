using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static ShopManager _manager = new ShopManager();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Catalog()
        {
            return View(_manager.GetAvailableItems());
        }

        public IActionResult Basket()
        {
            return View(_manager.Pay());
        }

        public IActionResult Buy(string name)
        {
            _manager.AddToBasket(name);

            return RedirectToAction(nameof(Catalog));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
