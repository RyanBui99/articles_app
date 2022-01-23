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

        [HttpGet]
        [Route("getPost/{id}")]
        public async Task<IActionResult> GetSingleBlogPost([FromRoute] string id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null) return BadRequest(new ResponseToClient
            { Message = "Blog post does not exist" });

            blogPost = new BlogPostModel {
                Id = blogPost.Id,
                Header = blogPost.Header,
                Content = blogPost.Content,
                Preview = blogPost.Preview,
                ImageName = blogPost.ImageName,
                ImageSrc = string.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, blogPost.ImageName)
            };

            return Ok(blogPost);
        }

        [HttpPut]
        [Route("editPost/{id}")]
        public async Task<IActionResult> EditBlogPost([FromRoute] string id, [FromForm] BlogPostModel editedPost)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);
            var imageNameOfEditedPost = await SaveImage(editedPost.ImageFile, false);

            if (blogPost == null) return BadRequest(new ResponseToClient { Message = "Blog post does not exist" });

            blogPost.Header = editedPost.Header;
            blogPost.Content = editedPost.Content;
            blogPost.Preview = CreatePreview(editedPost.Content);

            if (imageNameOfEditedPost == editedPost.ImageName)
            {
                await _context.SaveChangesAsync();
                return Ok(blogPost);
            } else
            {
                blogPost.ImageName = await SaveImage(editedPost.ImageFile, true);
                await _context.SaveChangesAsync();
                return Ok(blogPost);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> deleteBlogPost([FromRoute] string id)
        {
            var blogPostToDelete = await _context.BlogPosts.FindAsync(id);

            if (blogPostToDelete == null) return BadRequest(new ResponseToClient
            { Message="Blog post does not exist"});

            DeleteImage(blogPostToDelete.ImageName);
            _context.BlogPosts.Remove(blogPostToDelete);
            await _context.SaveChangesAsync();
            return Ok(new ResponseToClient { Message="Blog post delete successfully"});
        }

        [HttpPost]
        [Route("createPost")]
        public async Task<IActionResult> AddBlogPost([FromForm] BlogPostModel blogPost)
        {
            blogPost.ImageName = await SaveImage(blogPost.ImageFile, true);
            blogPost.Id = Guid.NewGuid().ToString();
            blogPost.Preview = CreatePreview(blogPost.Content);
            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();
            return Ok(blogPost);
        }

        /// <summary>
        /// Saves image to foler Images and save to db
        /// </summary>
        /// <param name="imageFile"></param>
        /// <returns></returns>
        [NonAction]
        private async Task<string> SaveImage(IFormFile imageFile, bool saveOrNot)
        {
            if (saveOrNot == true)
            {
                string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
                //imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
                var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
                return imageName;
            } else
            {
                string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
                //imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
                return imageName;
            }
        }

        /// <summary>
        /// Create a preview from the content
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [NonAction]
        private string CreatePreview(string content)
        {
            if (content.Length < 185) return content;

            var preview = content.Substring(0, 185);
            preview += "....";
            return preview;
        }

        /// <summary>
        /// When user deletes a blog post, delete connecting image from Images folder
        /// </summary>
        /// <param name="imageName"></param>
        [NonAction]
        private void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}
