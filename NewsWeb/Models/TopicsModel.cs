using NewsLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Models
{
    public class TopicsModel
    {
        public List<Topics> Topics { get; set; }

        public List<Articles> Articles { get; set; }

        public Topics ActiveTopic { get; set; }
    }
}
