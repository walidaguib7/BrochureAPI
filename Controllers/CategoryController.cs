using BrochureAPI.Data;
using BrochureAPI.Dtos.Category;
using BrochureAPI.Interfaces;
using BrochureAPI.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrochureAPI.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICategory _categoryRepo;
        public CategoryController(ApplicationDBContext context , ICategory category)
        {
            _context = context;
            _categoryRepo = category;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var categories = await _categoryRepo.GetCategories();
            var category = categories.Select(c => c.ToCategoryDto());
            return Ok(category);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var category = await _categoryRepo.GetCategory(id);
            if(category == null)
            {
                return NotFound();
            }
            return Ok(category.ToCategoryDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
             await _categoryRepo.DeleteCategory(id);
            return Ok("Category Deleted!");
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var category = categoryDto.ToCategory();
            var CategoryModel = await _categoryRepo.CreateCategory(category);
            if(CategoryModel == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetCategory), new { id = CategoryModel.Id } , CategoryModel.ToCategoryDto());
        }
    }
}
