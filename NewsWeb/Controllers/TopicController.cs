using Microsoft.AspNetCore.Mvc;
using NewsLogic.Managers;
using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Controllers
{
    public class TopicController : Controller
    {
        private TopicManager manager = new TopicManager();

        [HttpGet]
        public IActionResult Create()
        {
            TopicModel model = new TopicModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(TopicModel model)
        {
            // if valid -> save and send to another page
            if(ModelState.IsValid)
            {
                // manager call
                manager.CreateNew(model.Title);

                // send to start
                return RedirectToAction("Topics", "News");
            }

            // if not valid -> return back to the same view
            return View(model);
        }
    }
}
