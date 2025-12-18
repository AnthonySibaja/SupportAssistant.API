using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupportAssistant.API.DTOs;
using SupportAssistant.API.Interfaces;
using System.Security.Claims;

namespace SupportAssistant.API.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    [Authorize]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketDto dto)
        {
            var userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!
            );

            var ticket = await _ticketService.CreateAsync(userId, dto);
            return Ok(ticket);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ticketService.GetAllAsync());
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] string status)
        {
            await _ticketService.UpdateStatusAsync(id, status);
            return NoContent();
        }
    }
}
