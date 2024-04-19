namespace BrochureAPI.Helpers
{
    public class QueryObject
    {
        public string? Title { get; set; } = null;

        public string? SortBy { get; set; } = null;

        public bool IsDescending { get; set; } = false;

        public int PageNumber { get; set; } = 1;

        public int Limit { get; set; } = 20;
    }
}
