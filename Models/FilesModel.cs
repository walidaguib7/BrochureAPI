namespace BrochureAPI.Models
{
    public class FilesModel
    {
        public int Id { get; set; }

        public string FilePath { get; set; }
        public int BlogId { get; set; }

        public Blog blogs { get; set; }
    }
}
