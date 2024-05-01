using System.ComponentModel.DataAnnotations;

namespace BrochureAPI.Dtos.Files
{
    public class UploadFileDto
    {
        [Required]
        public string Content_Image { get; set; }
        [Required]
        public string Description_Image { get; set; }

    }
}
