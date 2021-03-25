using NewsLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Models
{
    public class ArticleModel
    {
        public Articles Article { get; set; }

        public Topics ArticleTopic { get; set; }

        public List<Topics> Topics { get; set; }

        public string Image { get; set; }
    }
}
