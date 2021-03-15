using Microsoft.AspNetCore.Mvc;
using NewsLogic;
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
            model.Topics = manager.GetAllTopics();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(TopicModel model)
        {
            // if valid -> save and send to another page
            if (ModelState.IsValid)
            {
                try
                {
                    // manager call
                    manager.CreateNew(model.Title);

                    return RedirectToAction(nameof(Create));
                }
                catch(LogicException ex)
                {
                    ModelState.AddModelError("validation", ex.Message);
                }
                catch(Exception ex)
                {
                    // some other unexpected error
                    ModelState.AddModelError("validation", ex.Message);
                }
            }

            // if not valid -> return back to the same view
            return View(model);
        }
    }
}
