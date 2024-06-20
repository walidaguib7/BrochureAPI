using BrochureAPI.Dtos.Blog;
using BrochureAPI.Models;


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
                FileId = blog.FileId,
                CategoryId = blog.category.Id,
                Image = blog.file.Image,
                UserId = blog.UserId,
                category_title = blog.category.Title,
                username = blog.user.UserName,
                
                
                


            };
        }

        public static  Blog ToBlogModel(this CreateBlogDto blog , int id , string user)
        
            => new Blog
            {
                Title = blog.Title,
                Description = blog.Description,
                Content = blog.Content,
                CategoryId = id,
                UserId = user,
                FileId = blog.FileId
            };
        }
    }

