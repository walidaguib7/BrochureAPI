using System.ComponentModel.DataAnnotations.Schema;

namespace BrochureAPI.Models
{
    [Table("Messages")]
    public class Messages
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string Message { get; set; }
    }
}
