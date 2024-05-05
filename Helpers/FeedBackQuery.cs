namespace BrochureAPI.Helpers
{
    public class FeedBackQuery
    {
        public string Username { get; set; }
        public int rating { get; set; }
        public string? SortBy { get; set; } = null;

        public bool IsDescending { get; set; } = false;

        public int PageNumber { get; set; } = 1;

        public int Limit { get; set; } = 20;
    }
}
