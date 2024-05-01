using System.ComponentModel.DataAnnotations.Schema;

namespace BrochureAPI.Models
{
    [Table("Services")]
    public class Services
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
