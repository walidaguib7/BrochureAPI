using BrochureAPI.Dtos.FeedBack;
using BrochureAPI.Models;

namespace BrochureAPI.Mappers
{
    public static class FeedBackMapper
    {
        public static FeedDto ToFeedDto(this FeedBack feedBack)
        {
            return new FeedDto
            {
                Id = feedBack.Id,
                Username = feedBack.Username,
                Testimonial = feedBack.Testimonial,
                rating = feedBack.rating
            };
        }


        public static FeedBack ToFeedModel(this CreateFeedDto feedDto)
        {
            return new FeedBack 
            {
               Username = feedDto.Username,
               Testimonial = feedDto.Testimonial,
               rating = feedDto.rating
            };
        }
    }
}
