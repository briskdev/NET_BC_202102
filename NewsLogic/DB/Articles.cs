using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewsLogic.DB
{
    public partial class Articles
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
    }
}
