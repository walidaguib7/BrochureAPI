using System.ComponentModel.DataAnnotations.Schema;

namespace BrochureAPI.Models
{
    [Table("Files")]
    public class FilesModel
    {
        public int Id { get; set; }

        public string Content_Image { get; set; }
        public string Description_Image { get; set; }
    }
}
