using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDotNetCore.Context;
using WebApiDotNetCore.Models;
using System.Globalization;
using System.Collections.Generic;
using WebApiDotNetCore.Context;
using WebApiDotNetCore.Managerr;
using WebApiDotNetCore.Interfaces.Manager;

namespace WebApiDotNetCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        //ApplicationDbContext __dbContext;
        IPostManager _postManager;
        //public PostController(ApplicationDbContext dbContext) 
        //{
        //    __dbContext = dbContext;
        //   //postManager = new PostManager(dbContext);

        //}
        public PostController(IPostManager postManager)
        {
            _postManager = postManager;
        }

        [HttpGet]
        public ActionResult<List<Post>> GetAll()
        {
            //var posts = __dbContext.Posts.ToList();
            var posts = _postManager.GetAll().ToList();
            return Ok(posts);
        }

        [HttpPost]
        public ActionResult<Post> Add(Post post)
        {
            post.CreatedDate = DateTime.Now;
            bool isSaved = _postManager.Add(post);
            //__dbContext.Posts.Add(post);
            //bool isSaved = __dbContext.SaveChanges() > 0;

            if (isSaved)
            {
                return Ok(post);
            }
            return BadRequest("Failed To Save");
        }

        [HttpGet("id")]

        public ActionResult<Post> GetById(int id)
        {
            var post = _postManager.GetById(id);
            if (post == null)
            {
                return BadRequest("Id not found !");
            }
            return Ok(post);
        }


        [HttpPut]

        public ActionResult<Post> Edit(Post post)
        {
            if(post.Id == 0)
            {
                return null;
            }
            bool isUpdate = _postManager.Update(post);
            if(isUpdate) 
            { 
                return Ok(post);
            }
                return BadRequest("Update Failed");
        }

        [HttpDelete("id")]
        public ActionResult<string> Delete(int id)
        {
            var post = _postManager.GetById(id);
            if(post.Id == null)
            {
                return BadRequest("Id Not Available");
            }
            else
            {
                bool isDelete = _postManager.Delete(post);
                if(isDelete)
                {
                    return Ok("Post has been deleted!");
                }
                else
                {
                    return BadRequest("Failed to delete!");
                }
            }
        }
    }
}
