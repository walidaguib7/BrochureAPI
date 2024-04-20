using System.ComponentModel.DataAnnotations;

namespace BrochureAPI.Dtos.Category
{
    public class CreateCategoryDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
