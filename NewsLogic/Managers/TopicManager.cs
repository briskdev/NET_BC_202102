using NewsLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsLogic.Managers
{
    public class TopicManager
    {
        public List<Topics> GetAllTopics()
        {
            //returns Topics, ordered by Title ASC
            using(var db = new NewsDb())
            {
                // SELECT * FROM Topics ORDER BY Title
                return db.Topics.OrderBy(t => t.Title).ToList();
            }
        }

        public Topics GetTopic(int id)
        {
            using(var db = new NewsDb())
            {
                return db.Topics.FirstOrDefault(t => t.Id == id);
            }
        }

        public void CreateNew(string title)
        {
            using(var db = new NewsDb())
            {
                // do validations
                // 0. Topic title must be defined
                if(String.IsNullOrEmpty(title))
                {
                    throw new LogicException("Title can't be empty!");
                }

                // 1. Topic title should be unique
                var sameTitle = db.Topics.FirstOrDefault(t => t.Title.ToLower() == title.ToLower());
                if(sameTitle != null)
                {
                    throw new LogicException("Topic already exists!");
                }

                db.Topics.Add(new Topics()
                {
                    Title = title,
                });

                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using(var db = new NewsDb())
            {
                var topic = db.Topics.FirstOrDefault(t => t.Id == id);
                db.Topics.Remove(topic);

                db.SaveChanges();
            }
        }

        public void Update(int id, string title)
        {
            using(var db = new NewsDb())
            {
                // find the topic
                var topic = db.Topics.FirstOrDefault(t => t.Id == id);

                // modify it's data
                topic.Title = title;

                // save changes
                db.SaveChanges();
            }
        }
    }
}
