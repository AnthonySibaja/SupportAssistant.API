using SupportAssistant.API.DTOs;
using SupportAssistant.API.Models;

namespace SupportAssistant.API.Interfaces
{
    public interface ITicketService
    {
        Task<Ticket> CreateAsync(int userId, CreateTicketDto dto);
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task<Ticket?> GetByIdAsync(int id);
        Task UpdateStatusAsync(int id, string status);
    }
}
