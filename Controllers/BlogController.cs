using BrochureAPI.Data;
using BrochureAPI.Dtos.Blog;
using BrochureAPI.Extensions;
using BrochureAPI.Helpers;
using BrochureAPI.Interfaces;
using BrochureAPI.Mappers;
using BrochureAPI.Models;
using BrochureAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _manager;
        public BlogController(ApplicationDBContext context , IBlog BlogRepo , UserManager<User> manager)
        {
            _context = context;
            _BlogRepo = BlogRepo;
            _manager = manager;

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
        [Authorize]
        public async Task<IActionResult> CreateBlogs([FromRoute] int id , [FromBody] CreateBlogDto blogDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _manager.FindByNameAsync(User.GetUsername());
            if(user == null)
            {
                return NotFound();
            }
            var blog = blogDto.ToBlogModel(id, user.Id);
            await _BlogRepo.CreateAsync(blog);
            return Ok("Blog Created");
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateBlog([FromRoute] int id , [FromBody] UpdateBlogDto blogDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var blog = await _BlogRepo.UpdateBlog(id, blogDto);
            if(blog == null){
                return NotFound();
            };

            return Ok(blog.ToBlogDto());
        }






    }
}
