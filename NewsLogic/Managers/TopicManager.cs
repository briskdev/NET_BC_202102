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
    }
}
