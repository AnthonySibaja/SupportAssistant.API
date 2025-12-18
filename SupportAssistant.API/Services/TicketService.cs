using Microsoft.EntityFrameworkCore;
using SupportAssistant.API.Data;
using SupportAssistant.API.DTOs;
using SupportAssistant.API.Interfaces;
using SupportAssistant.API.Models;

namespace SupportAssistant.API.Services
{
    public class TicketService : ITicketService
    {
        private readonly AppDbContext _context;

        public TicketService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Ticket> CreateAsync(int userId, CreateTicketDto dto)
        {
            var ticket = new Ticket
            {
                UserId = userId,
                Title = dto.Title,
                Description = dto.Description,
                Status = "Open"
            };

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _context.Tickets
                .Include(t => t.User)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _context.Tickets
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateStatusAsync(int id, string status)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
                throw new Exception("Ticket no encontrado");

            ticket.Status = status;
            await _context.SaveChangesAsync();
        }
    }
}
