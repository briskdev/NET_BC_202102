using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsLogic.Managers;
using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Controllers
{
    public class HomeController : Controller
    {
        private NewsManager newsManager = new NewsManager();

        // latest news
        public IActionResult Index()
        {
            var latestNews = newsManager.GetLatestNews();

            return View(latestNews);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
