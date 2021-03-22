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
        public IActionResult Create(int? id)
        {
            // Page available only to administrators
            if(!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }

            TopicModel model = new TopicModel();
            model.Topics = manager.GetAllTopics();

            // id ID is defined -> topic editing
            if(id.HasValue)
            {
                var data = manager.GetTopic(id.Value);
                model.Title = data.Title;
                model.Id = data.Id;
            }

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
                    // if id is not set -> creating a new topic
                    if(model.Id == 0)
                    {
                        // manager call
                        manager.CreateNew(model.Title);
                    }
                    // ID is defined -> editing topic
                    else
                    {
                        manager.Update(model.Id, model.Title);
                    }

                    return RedirectToAction(nameof(Index));
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Page available only to administrators
            if (!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }

            // topic from DB
            var data = manager.GetTopic(id);

            TopicModel model = new TopicModel();
            model.Topics = manager.GetAllTopics();
            // fill in model with a data from DB
            model.Title = data.Title;
            model.Id = data.Id;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TopicModel model)
        {
            // if valid -> save and send to another page
            if (ModelState.IsValid)
            {
                try
                {
                    // manager call
                    manager.Update(model.Id, model.Title);

                    return RedirectToAction(nameof(Index));
                }
                catch (LogicException ex)
                {
                    ModelState.AddModelError("validation", ex.Message);
                }
                catch (Exception ex)
                {
                    // some other unexpected error
                    ModelState.AddModelError("validation", ex.Message);
                }
            }

            // if not valid -> return back to the same view
            return View(model);
        }

        public IActionResult Index()
        {
            if(!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }

            var topics = manager.GetAllTopics();

            return View(topics);
        }

        public IActionResult Delete(int id)
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }

            manager.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
