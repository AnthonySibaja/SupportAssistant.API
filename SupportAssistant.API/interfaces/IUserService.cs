using SupportAssistant.API.DTOs;
using SupportAssistant.API.Models;

namespace SupportAssistant.API.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterAsync(RegisterUserDto dto);
        Task<string> LoginAsync(LoginDto dto);
        Task<User?> GetByIdAsync(int userId);
    }
}
