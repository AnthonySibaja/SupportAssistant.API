using Microsoft.EntityFrameworkCore;
using SupportAssistant.API.Data;
using SupportAssistant.API.DTOs;
using SupportAssistant.API.Helpers;
using SupportAssistant.API.Interfaces;
using SupportAssistant.API.Models;
using System.Security.Cryptography;
using System.Text;

namespace SupportAssistant.API.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly JwtHelper _jwtHelper;

        public UserService(AppDbContext context, JwtHelper jwtHelper)
        {
            _context = context;
            _jwtHelper = jwtHelper;
        }

        public async Task<User> RegisterAsync(RegisterUserDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                throw new Exception("El correo ya está registrado");

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password),
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
                throw new Exception("Credenciales inválidas");

            return _jwtHelper.GenerateToken(user);
        }

        public async Task<User?> GetByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        // ===============================
        // PASSWORD HASH
        // ===============================
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}
