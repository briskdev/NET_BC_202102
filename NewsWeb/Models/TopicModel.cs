using NewsLogic.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Models
{
    public class TopicModel
    {
        [Required]
        [Display(Name = "Topic name")]
        public string Title { get; set; }

        [Display(Name = "Topic description")]
        public string Description { get; set; }

        // under which topic this one should be created
        [Display(Name = "Parent topic")]
        public int? ParentTopicId { get; set; }

        public List<Topics> Topics { get; set; }
    }
}
