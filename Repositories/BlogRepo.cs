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

        public static async Task<string> UploadImage(IFormFile image)
        {
            if (image.Length == 0 || image == null)
            {
                throw new Exception("Image Not Found!");
            }
            if (image.Length > 1048576) // 1 MB limit
            {
                throw new Exception("The maximum image size must be 1mb!");
            }
            var AllowedExtensions = new List<string> { ".jpg", ".jpeg", ".png" };
            var extension = Path.GetExtension(image.FileName).ToLower();
            if (!AllowedExtensions.Contains(extension))
            {
                throw new Exception("Invalid image format. Only JPG, JPEG, and PNG files are allowed.");
            }
            string fileName = Path.GetFileName(image.FileName);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
            string filePath = Path.Combine(@"D:\AW7\BrochureAPI\Uploads\Blog", uniqueFileName);

            try
            {
                await using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return  uniqueFileName;
        }


        public async Task<Blog?> CreateBlog(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return blog;
            
            throw new NotImplementedException();
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

        public Task<Blog?> UpdateBlog(int id, UpdateBlogDto updateBlogDto)
        {
            throw new NotImplementedException();
        }
    }
}
