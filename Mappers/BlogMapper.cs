using BrochureAPI.Dtos.Blog;
using BrochureAPI.Models;
using BrochureAPI.Repositories;

namespace BrochureAPI.Mappers
{
    public static class BlogMapper
    {
        public static BlogDto ToBlogDto(this Blog blog) => new BlogDto
        {
            Id = blog.Id,
            Title = blog.Title,
            Description = blog.Description,
            Content = blog.Content,
            FileId = blog.FileId,
            CategoryId = (int)blog.CategoryId

        };


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

