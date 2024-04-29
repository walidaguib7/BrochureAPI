using BrochureAPI.Dtos.Blog;
using BrochureAPI.Helpers;
using BrochureAPI.Models;

namespace BrochureAPI.Interfaces
{
    public interface IBlog
    {
        Task<List<Blog>> GetAllBlogs(BlogQuery query);
        Task<Blog?> GetBlog(int id);
        Task<Blog> CreateAsync(Blog blog);
        Task<Blog?> UpdateBlog(int id , UpdateBlogDto updateBlogDto);
        Task<Blog?> DeleteBlog(int id);
        
    }
}
