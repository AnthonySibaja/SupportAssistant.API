using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportAssistant.API.Models
{
    public class Ticket
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public User User { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Category { get; set; }

    public string? Priority { get; set; }

    public string Status { get; set; } = "Open";

    public string? AiSummary { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

}
