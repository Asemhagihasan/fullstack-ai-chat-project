using ChatSentimentAPI.Data;
using ChatSentimentAPI.DTOs;
using ChatSentimentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UsersController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult> CreateUserAsync([FromBody] RegisterUserDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.Nickname.ToLower() == dto.Nickname.ToLower());

            if (existingUser != null)
            {
                return BadRequest(new { message = "Nickname already exists" });
            }

            var user = new User
            {
                Nickname = dto.Nickname.Trim(),
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}
