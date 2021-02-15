using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// http://www.mypage.com/
// http://localhost/
namespace ShopWeb.Controllers
{
    // controller
    // http://www.mypage.com/Home/
    // http://localhost/Home/
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // action Index
        // real page: 
        // http://www.mypage.com/Home/Index
        // http://localhost/Home/Index
        public IActionResult Index()
        {
            return View();
        }

        // http://www.mypage.com/Home/Privacy
        // http://localhost/Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
