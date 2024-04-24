using BrochureAPI.Dtos.Blog;
using BrochureAPI.Models;

namespace BrochureAPI.Interfaces
{
    public interface IBlog
    {
        Task<List<Blog>> GetAllBlogs();
        Task<Blog?> GetBlog(int id);
        Task<Blog?> CreateBlog(Blog blog);
        Task<Blog?> UpdateBlog(int id , UpdateBlogDto updateBlogDto);
        Task<Blog?> DeleteBlog(int id);
    }
}
