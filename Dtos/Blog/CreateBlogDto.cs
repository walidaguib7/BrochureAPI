using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BrochureAPI.Dtos.Blog
{
    public class CreateBlogDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public int FileId { get; set; }


    }
}
