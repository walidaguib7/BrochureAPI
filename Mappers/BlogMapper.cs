using BrochureAPI.Dtos.Blog;
using BrochureAPI.Models;
using BrochureAPI.Repositories;

namespace BrochureAPI.Mappers
{
    public static class BlogMapper
    {
        public static BlogDto ToBlogDto(this Blog blog)
        {
            return new BlogDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                Content = blog.Content,
                Image = blog.Image
            };
        }


        public static async Task<Blog> ToBlogModel(this CreateBlogDto blog  , int id , string user)
        {

            var file = await BlogRepo.UploadImage(blog.Image);

            return new Blog
            {
                Title = blog.Title,
                Description = blog.Description,
                Content = blog.Content,
                Image = file,
                CategoryId = id,
                UserId = user

            };
        }
    }
}
