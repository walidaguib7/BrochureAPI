using BrochureAPI.Models;

namespace BrochureAPI.Interfaces
{
    public interface ICategory
    {
        Task<List<Category>> GetCategories();
        Task<Category?> GetCategory(int id);
        Task<Category?> DeleteCategory(int id);

        Task<Category?> CreateCategory(Category category);
    }
}
