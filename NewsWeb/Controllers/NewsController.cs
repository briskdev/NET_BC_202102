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

        // single article
        public IActionResult Article(int? id)
        {
            ArticleModel model = new ArticleModel();
            if(id.HasValue)
            {
                // one specific article is selected
                // select * from Articles
                model.Article = articles.GetById(id.Value);
                model.Topics = topics.GetAllTopics();
                // select * from Topics Where Id = Article.TopicId
                model.ArticleTopic = topics.GetTopic(model.Article.TopicId);
            }

            return View(model);
        }

        public IActionResult Index()
        {
            if(!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }
            var data = articles.GetAll();

            return View(data);
        }

        public IActionResult Delete(int id)
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }

            articles.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }

            var model = new CreateArticleModel();
            model.Author = HttpContext.Session.GetUsername();
            model.Topics = topics.GetAllTopics();

            if(id.HasValue)
            {
                var data = articles.GetById(id.Value);
                model.Author = data.Author;
                model.Id = data.Id;
                model.Text = data.Text;
                model.Title = data.Title;
                model.TopicId = data.TopicId;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateArticleModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if (model.Id == 0)
                    {
                        articles.Create(model.TopicId, model.Title, model.Text, model.Author);
                    }
                    else
                    {
                        // id is defined -> update
                        articles.Update(model.Id, model.TopicId, model.Title, model.Text, model.Author);
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch(LogicException ex)
                {
                    ModelState.AddModelError("validation", ex.Message);
                }
            }

            model.Topics = topics.GetAllTopics();
            return View(model);
        }
    }
}
