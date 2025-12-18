using System.ComponentModel.DataAnnotations;

namespace SupportAssistant.API.DTOs
{
    public class ChatRequestDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
