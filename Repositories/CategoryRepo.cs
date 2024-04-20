using BrochureAPI.Data;
using BrochureAPI.Interfaces;
using BrochureAPI.Mappers;
using BrochureAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BrochureAPI.Repositories
{
    public class CategoryRepo : ICategory
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Category?> CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null)
            {
                return null;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category?> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null)
            {
                return null;
            }

            return category;
        }
    }
}
