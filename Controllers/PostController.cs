using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDotNetCore.Context;
using WebApiDotNetCore.Models;
using System.Globalization;
using System.Collections.Generic;
using WebApiDotNetCore.Context;

namespace WebApiDotNetCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        ApplicationDbContext __dbContext;
        public PostController(ApplicationDbContext dbContext) 
        {
            __dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Post>> GetAll()
        {
            var posts = __dbContext.Posts.ToList();
            return Ok(posts);
        }

        [HttpPost]
        public Post Add(Post post)
        {
            post.CreatedDate = DateTime.Now;
            __dbContext.Posts.Add(post);
            bool isSaved = __dbContext.SaveChanges() > 0;
            if (isSaved)
            {
                return post;
            }
            return null;
        }

    }
}
