using System.ComponentModel.DataAnnotations;

namespace BrochureAPI.Dtos.Files
{
    public class UploadFileDto
    {
        [Required]
        public string Image { get; set; }


    }
}
