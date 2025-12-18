using System.ComponentModel.DataAnnotations;

namespace SupportAssistant.API.DTOs
{
    public class CreateTicketDto
    {
        [Required]
        [MaxLength(200)]
        public required string Title { get; set; }

        [Required]
        public required string Description { get; set; }
    }
}
