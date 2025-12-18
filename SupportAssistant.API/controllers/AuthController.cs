using Microsoft.AspNetCore.Mvc;
using SupportAssistant.API.DTOs;
using SupportAssistant.API.Interfaces;

namespace SupportAssistant.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            var user = await _userService.RegisterAsync(dto);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _userService.LoginAsync(dto);
            return Ok(new { token });
        }
    }
}
