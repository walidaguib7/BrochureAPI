using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrochureAPI.Models
{

    [Table("Blog")]
    public class Blog
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        
        public int CategoryId { get; set; }
        public string UserId { get; set; }

        public int FileId { get; set; }

        public Category category { get; set; }

        public User user { get; set; }

        public FilesModel file { get; set; }




    }
}
