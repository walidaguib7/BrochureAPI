using BrochureAPI.Data;
using BrochureAPI.Dtos.Blog;
using BrochureAPI.Helpers;
using BrochureAPI.Interfaces;
using BrochureAPI.Mappers;
using BrochureAPI.Models;
using BrochureAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrochureAPI.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IBlog _BlogRepo;
        private readonly User user;
        public BlogController(ApplicationDBContext context , IBlog BlogRepo)
        {
            _context = context;
            _BlogRepo = BlogRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] BlogQuery query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var blogs = await _BlogRepo.GetAllBlogs(query);
            var blog = blogs.Select(b => b.ToBlogDto());
            return Ok(blog);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetBlog([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var blog = await _BlogRepo.GetBlog(id);
            if(blog == null)
            {
                return NotFound();
            }
            return Ok(blog.ToBlogDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteBlog([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _BlogRepo.DeleteBlog(id);
            return Ok("Blog Deleted!");

        }


        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogDto blogDto  , [FromRoute] int id)
        {
            
            var blog = await blogDto.ToBlogModel(id,user.Id);
            var BlogModel = await _BlogRepo.CreateBlog(blog);
            return Ok(BlogModel.ToBlogDto());
        }



    }
}
