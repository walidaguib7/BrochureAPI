using System.ComponentModel.DataAnnotations;

namespace BrochureAPI.Dtos.FeedBack
{
    public class CreateFeedDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Testimonial { get; set; }

        [Required]
        public int rating { get; set; }
    }
}
