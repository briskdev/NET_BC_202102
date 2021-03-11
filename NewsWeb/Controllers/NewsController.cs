using Microsoft.AspNetCore.Mvc;
using NewsLogic.Managers;
using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Controllers
{
    public class NewsController : Controller
    {
        private TopicManager topics = new TopicManager();
        private NewsManager articles = new NewsManager();


        public IActionResult Topics(int? id)
        {
            TopicsModel model = new TopicsModel();
            model.Topics = topics.GetAllTopics();
            if(id.HasValue)
            {
                // retrieve articles
                model.ActiveTopic = topics.GetTopic(id.Value);
                // retrieve active topic info
                model.Articles = articles.GetByTopic(id.Value);
            }

            return View(model);
        }

        public IActionResult Article()
        {
            return View();
        }
    }
}
