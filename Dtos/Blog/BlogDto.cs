namespace BrochureAPI.Dtos.Blog
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }

        public int FileId { get; set; }

        public string Image { get; set; }

        public string category_title { get; set; }

        public string username { get; set; }


        

    }
}
