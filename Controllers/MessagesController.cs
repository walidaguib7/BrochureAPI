using BrochureAPI.Data;
using BrochureAPI.Dtos.Messages;
using BrochureAPI.Helpers;
using BrochureAPI.Interfaces;
using BrochureAPI.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrochureAPI.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IMessages _messagesRepo;
        public MessagesController(ApplicationDBContext context , IMessages messagesRepo)
        {
            _context = context;
            _messagesRepo = messagesRepo;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllMessages([FromQuery] MessagesQuery query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var messages = await _messagesRepo.GetAll(query);
            var message = messages.Select(m => m.ToMessageDto());
            return Ok(message);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetMessage([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var message = await _messagesRepo.GetMessage(id);
            if (message == null) return NotFound();
            return Ok(message.ToMessageDto());
        }




        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteMessage([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _messagesRepo.DeleteMessage(id);
            return Ok("Message deleted!");

        }


        [HttpPost]
        public async Task<IActionResult> SendMessages([FromBody] SendMessageDto messageDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var message = messageDto.ToMessageModel();
            await _messagesRepo.SendMessage(message);
            return Ok(message.ToMessageDto());
        }
    }
}
