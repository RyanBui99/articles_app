using articles_app.Data;
using articles_app.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace articles_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public BlogPostController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        [Route("getPosts")]
        public IActionResult GetAllPosts()
        {
            var list = new List<BlogPostModel>();

            foreach (var blogPost in _context.BlogPosts.ToList())
            {
                list.Add(new BlogPostModel()
                {
                    Id = blogPost.Id,
                    Header = blogPost.Header,
                    Content = blogPost.Content,
                    Preview = blogPost.Preview,
                    ImageName = blogPost.ImageName,
                    ImageSrc = string.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, blogPost.ImageName)
                });
            }
            return Ok(list);
        }

        [HttpPost]
        [Route("createPost")]
        public async Task<IActionResult> AddBlogPost([FromForm] BlogPostModel blogPost)
        {
            blogPost.ImageName = await SaveImage(blogPost.ImageFile);
            blogPost.Id = Guid.NewGuid().ToString();
            blogPost.Preview = createPreview(blogPost.Content);
            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();
            return Ok(new ResponseToClient { Message = "Image" });
        }

        /// <summary>
        /// Saves image to foler Images and save to db
        /// </summary>
        /// <param name="imageFile"></param>
        /// <returns></returns>
        [NonAction]
        private async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        /// <summary>
        /// Create a preview from the content
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [NonAction]
        private string createPreview(string content)
        {
            var preview = content.Substring(0, 185);
            preview += "....";
            return preview;
        }
    }
}
