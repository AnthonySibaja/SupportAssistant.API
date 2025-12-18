using Microsoft.AspNetCore.Mvc;
using SupportAssistant.API.Data;

namespace SupportAssistant.API.Controllers
{
    [ApiController]
    [Route("api/db-test")]
    public class DbTestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DbTestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult TestConnection()
        {
            var canConnect = _context.Database.CanConnect();
            return Ok(new
            {
                databaseConnected = canConnect
            });
        }
    }
}
