using NewsLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsLogic.Managers
{
    public class NewsManager
    {
        public List<Articles> GetLatestNews(int count = 6)
        {
            using(var db = new NewsDb())
            {
                // SELECT TOP 6 * FROM Articles ORDER BY PublishedOn DESC
                return db.Articles.OrderByDescending(a => a.PublishedOn).Take(count).ToList();
            }
        }

        public List<Articles> GetByTopic(int topicId)
        {
            using(var db = new NewsDb())
            {
                return db.Articles
                    // under specific topic
                    .Where(a => a.TopicId == topicId)
                    // latest first
                    .OrderByDescending(a => a.PublishedOn)
                    .ToList();
            }
        }
    }
}
