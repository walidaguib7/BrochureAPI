using System.ComponentModel.DataAnnotations;

namespace BrochureAPI.Dtos.Messages
{
    public class SendMessageDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(length:20 , ErrorMessage = "the message must contains at least 20 caracters")]
        public string Message { get; set; }
    }
}
