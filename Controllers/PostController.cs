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
        public IActionResult GetAll()
        {
            try
            {
                //var posts = __dbContext.Posts.ToList();
                var posts = _postManager.GetAll().ToList();
                return Ok(posts);
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
         
        }

        [HttpPost]
        public IActionResult Add(Post post)
        {
            try
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
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("id")]

        public IActionResult GetById(int id)
        {
            try
            {
                var post = _postManager.GetById(id);
                if (post == null)
                {
                    return BadRequest("Id not found !");
                }
                return Ok(post);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut]

        public IActionResult Edit(Post post)
        {
            try
            {
                if (post.Id == 0)
                {
                    return null;
                }
                bool isUpdate = _postManager.Update(post);
                if (isUpdate)
                {
                    return Ok(post);
                }
                return BadRequest("Update Failed");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message) ;
            }
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var post = _postManager.GetById(id);
                if (post.Id == null)
                {
                    return BadRequest("Id Not Available");
                }
                else
                {
                    bool isDelete = _postManager.Delete(post);
                    if (isDelete)
                    {
                        return Ok("Post has been deleted!");
                    }
                    else
                    {
                        return BadRequest("Failed to delete!");
                    }
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
