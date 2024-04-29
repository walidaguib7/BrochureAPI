using System.ComponentModel.DataAnnotations;

namespace BrochureAPI.Dtos.Files
{
    public class UploadFileDto
    {
        [Required]
        public string FilePath { get; set; }
        [Required]
        public int BlogId { get; set; }
    }
}
