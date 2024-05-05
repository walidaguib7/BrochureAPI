using System.ComponentModel.DataAnnotations.Schema;

namespace BrochureAPI.Models
{
    [Table("FeedBack")]
    public class FeedBack
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Testimonial { get; set; }
        public int rating { get; set; }
    }
}
