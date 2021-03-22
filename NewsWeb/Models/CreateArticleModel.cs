using NewsLogic.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Models
{
    public class CreateArticleModel
    {
        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Text")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Display(Name = "Topic")]
        [Required]
        public int TopicId { get; set; }

        [Display(Name = "Author")]
        [Required]
        public string Author { get; set; }

        public List<Topics> Topics { get; set; }

        public int Id { get; set; }
    }
}
