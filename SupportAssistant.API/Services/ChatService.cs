using SupportAssistant.API.Data;
using SupportAssistant.API.DTOs;
using SupportAssistant.API.Interfaces;
using SupportAssistant.API.Models;

namespace SupportAssistant.API.Services
{
    public class ChatService : IChatService
    {
        private readonly AppDbContext _context;
        private readonly IOpenAIService _openAIService;

        public ChatService(AppDbContext context, IOpenAIService openAIService)
        {
            _context = context;
            _openAIService = openAIService;
        }

        public async Task<ChatResponseDto> ProcessMessageAsync(
            int userId,
            ChatRequestDto dto)
        {
            var (response, category, priority) =
                await _openAIService.GetSupportResponseAsync(dto.Message);

            var chat = new ChatMessage
            {
                UserId = userId,
                UserMessage = dto.Message,
                AiResponse = response,
                Category = category,
                Priority = priority
            };

            _context.ChatMessages.Add(chat);
            await _context.SaveChangesAsync();

            return new ChatResponseDto
            {
                Response = response,
                Category = category,
                Priority = priority
            };
        }
    }
}
