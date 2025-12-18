using SupportAssistant.API.DTOs;

namespace SupportAssistant.API.Interfaces
{
    public interface IChatService
    {
        Task<ChatResponseDto> ProcessMessageAsync(int userId, ChatRequestDto dto);
    }
}
