namespace BrochureAPI.Dtos.Blog
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
