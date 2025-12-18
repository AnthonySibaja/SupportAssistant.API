using System.ComponentModel.DataAnnotations;

namespace SupportAssistant.API.DTOs
{
    public class RegisterUserDto
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public required string Email { get; set; }

        [Required]
        [MinLength(6)]
        public required string Password { get; set; }
    }
}
