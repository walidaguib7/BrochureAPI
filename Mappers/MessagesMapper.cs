using BrochureAPI.Dtos.Messages;
using BrochureAPI.Models;

namespace BrochureAPI.Mappers
{
    public static class MessagesMapper
    {
        public static MessagesDto ToMessageDto(this Messages messages)
        {
            return new MessagesDto
            {
                Id = messages.Id,
                Email = messages.Email,
                Message = messages.Message,
            };
        }

        public static Messages ToMessageModel(this SendMessageDto messageDto)
        {
            return new Messages
            {
                Email = messageDto.Email,
                Message = messageDto.Message
            };
        }
    }
}
