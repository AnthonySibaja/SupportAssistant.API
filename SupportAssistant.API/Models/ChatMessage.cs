using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportAssistant.API.Models
{
    public class ChatMessage
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public User User { get; set; } = null!;

    public string UserMessage { get; set; } = null!;

    public string AiResponse { get; set; } = null!;

    public string? Category { get; set; }

    public string? Priority { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
}
