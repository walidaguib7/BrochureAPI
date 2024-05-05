using BrochureAPI.Data;
using BrochureAPI.Helpers;
using BrochureAPI.Interfaces;
using BrochureAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BrochureAPI.Repositories
{
    public class FeedBackRepo : IFeed
    {
        private readonly ApplicationDBContext _context;

        public FeedBackRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<FeedBack?> DeleteFeedBack(int id)
        {
            var feed = await _context.FeedBacks.FindAsync(id);
            if (feed == null) return null;
            _context.FeedBacks.Remove(feed);
            await _context.SaveChangesAsync();
            return feed;
        }

        public async Task<List<FeedBack>> GetAllFeeds(FeedBackQuery query)
        {
            var feeds = _context.FeedBacks.AsQueryable();

            if (!string.IsNullOrEmpty(query.Username))
            {
                feeds = feeds.Where(b => b.Username.Contains(query.Username));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("username", StringComparison.OrdinalIgnoreCase))
                {
                    feeds = query.IsDescending ? feeds.OrderByDescending(s => s.Username) : feeds.OrderBy(s => s.Username);
                }
                if (query.SortBy.Equals("rating", StringComparison.OrdinalIgnoreCase))
                {
                    feeds = query.IsDescending ? feeds.OrderByDescending(s => s.rating) : feeds.OrderBy(s => s.rating);
                }
            }
            var skipNumber = (query.PageNumber - 1) * query.Limit;
            return await feeds.Skip(skipNumber).Take(query.Limit).ToListAsync();
        }

        public async Task<FeedBack?> GetFeedBack(int id)
        {
            return await _context.FeedBacks.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<FeedBack> SendFeedBack(FeedBack feedBack)
        {
            await _context.FeedBacks.AddAsync(feedBack);
            await _context.SaveChangesAsync();
            return feedBack;
        }
    }
}
