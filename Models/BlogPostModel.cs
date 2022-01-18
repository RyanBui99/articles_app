using System;
using System.ComponentModel.DataAnnotations;

namespace articles_app.Models
{
    public class BlogPostModel
    {
        public string ImageUrl { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
