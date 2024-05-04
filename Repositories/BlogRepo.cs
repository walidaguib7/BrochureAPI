using BrochureAPI.Data;
using BrochureAPI.Dtos.Blog;
using BrochureAPI.Helpers;
using BrochureAPI.Interfaces;
using BrochureAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BrochureAPI.Repositories
{
    public class BlogRepo : IBlog
    {
        private readonly ApplicationDBContext _context;

        public BlogRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        


        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

  

        public async Task<Blog?> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<List<Blog>> GetAllBlogs(BlogQuery query)
        {
            var blogs =  _context.Blogs.Include(c => c.category).AsQueryable();

            if (!string.IsNullOrEmpty(query.Title))
            {
                blogs = blogs.Where(b => b.Title.Contains(query.Title));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    blogs = query.IsDescending ? blogs.OrderByDescending(s => s.Title) : blogs.OrderBy(s => s.Title);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.Limit;
            return await blogs.Skip(skipNumber).Take(query.Limit).ToListAsync();

        }

        public async Task<Blog?> GetBlog(int id)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            return blog;
        }

        public async Task<Blog?> UpdateBlog(int id, UpdateBlogDto updateBlogDto)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            if(blog == null)
            {
                return null;
            };
            blog.Title = updateBlogDto.Title;
            blog.Description = updateBlogDto.Description;
            blog.Content = updateBlogDto.Content;
            blog.CategoryId = updateBlogDto.CategoryId;
            blog.FileId = updateBlogDto.FileId;
            await _context.SaveChangesAsync();
            return blog;
            
        }
    }
}
