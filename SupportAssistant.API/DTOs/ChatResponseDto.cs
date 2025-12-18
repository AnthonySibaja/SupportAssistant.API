namespace SupportAssistant.API.DTOs
{
    public class ChatResponseDto
    {
        public required string Response { get; set; }
        public required string Category { get; set; }
        public required string Priority { get; set; }
    }
}
