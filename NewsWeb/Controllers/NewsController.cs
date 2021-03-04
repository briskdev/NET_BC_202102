using Microsoft.AspNetCore.Mvc;
using NewsLogic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Controllers
{
    public class NewsController : Controller
    {
        private TopicManager topics = new TopicManager();


        public IActionResult Topics()
        {
            var data = topics.GetAllTopics();

            return View(data);
        }

        public IActionResult Article()
        {
            return View();
        }
    }
}
