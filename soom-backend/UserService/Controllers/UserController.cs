using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Data;
using UserService.Models;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
        
        public UserController(UserContext context)
        {
            _context = context;
        }
        
        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe([FromBody] string email)
        {
            var user = new User { Email = email };  
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Email subscribed successfully", email });
        }
    }
}
