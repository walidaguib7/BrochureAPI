namespace BrochureAPI.Dtos.Blog
{
    public class UpdateBlogDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int FileId { get; set; }
    }
}
