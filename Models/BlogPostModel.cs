using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace articles_app.Models
{
    public class BlogPostModel
    {
        public string ImageName { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        [Key]
        public string Id { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set;}
        [NotMapped]
        public string ImageSrc { get; set; }
    }
}
