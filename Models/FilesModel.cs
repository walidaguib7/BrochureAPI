using System.ComponentModel.DataAnnotations.Schema;

namespace BrochureAPI.Models
{
    [Table("Files")]
    public class FilesModel
    {
        public int Id { get; set; }

        public string Image { get; set; }
    }
}
