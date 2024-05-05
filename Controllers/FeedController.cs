using BrochureAPI.Data;
using BrochureAPI.Dtos.FeedBack;
using BrochureAPI.Helpers;
using BrochureAPI.Interfaces;
using BrochureAPI.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrochureAPI.Controllers
{
    [Route("api/feedback")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IFeed feedRepo;
        public FeedController(ApplicationDBContext context , IFeed feed)
        {
            _context = context;
            feedRepo = feed;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FeedBackQuery query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var feeds = await feedRepo.GetAllFeeds(query);
            var feed = feeds.Select(f => f.ToFeedDto());
            return Ok(feed);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetFeedBack([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var feed = await feedRepo.GetFeedBack(id);
            if (feed == null) return NotFound();
            return Ok(feed.ToFeedDto());
        }


        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteFeed([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await feedRepo.DeleteFeedBack(id);
            return Ok("Feed deleted!");
        }

        [HttpPost]
        public async Task<IActionResult> SendFeedBack([FromBody] CreateFeedDto feedDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var FeedModel = feedDto.ToFeedModel();
            var feed = await feedRepo.SendFeedBack(FeedModel);
            if(feed == null)
            {
                return NotFound();
            }
            return Ok(feed.ToFeedDto());
        }
    }
}
