using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupportAssistant.API.DTOs;
using SupportAssistant.API.Interfaces;
using System.Security.Claims;

namespace SupportAssistant.API.Controllers
{
    [ApiController]
    [Route("api/chat")]
    [Authorize]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(ChatRequestDto dto)
        {
            var userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!
            );

            var response = await _chatService.ProcessMessageAsync(userId, dto);
            return Ok(response);
        }
    }
}
