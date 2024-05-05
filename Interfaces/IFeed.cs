using BrochureAPI.Helpers;
using BrochureAPI.Models;

namespace BrochureAPI.Interfaces
{
    public interface IFeed
    {
        Task<List<FeedBack>> GetAllFeeds(FeedBackQuery query);
        Task<FeedBack?> GetFeedBack(int id);
        Task<FeedBack?> DeleteFeedBack(int id);
        Task<FeedBack> SendFeedBack(FeedBack feedBack);
    }
}
