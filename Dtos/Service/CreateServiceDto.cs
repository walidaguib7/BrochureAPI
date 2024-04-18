using System.ComponentModel.DataAnnotations;

namespace BrochureAPI.Dtos.Service
{
    public class CreateServiceDto
    {
        [Required]
        [MinLength(8 , ErrorMessage ="The title should has at least 8 characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(30, ErrorMessage = "The Description should has at least 30 characters")]
        public string Description { get; set; } = string.Empty;
    }
}
