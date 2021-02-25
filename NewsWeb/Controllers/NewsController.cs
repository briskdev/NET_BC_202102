using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Topics()
        {
            return View();
        }

        public IActionResult Article()
        {
            return View();
        }
    }
}
