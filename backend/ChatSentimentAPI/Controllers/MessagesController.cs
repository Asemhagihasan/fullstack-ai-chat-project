using ChatSentimentAPI.Data;
using ChatSentimentAPI.DTOs;
using ChatSentimentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatSentimentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly DataContext _context;
        public MessagesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetMessagesAsync(int userId)
        {

            var messages = await _context.Messages.Where(m => m.UserId == userId).ToListAsync();

            var messageDtos = messages.Select(m => new MessageDto
            {
                Id = m.Id,
                Content = m.Content,
                UserId = m.UserId,
                CreatedAt = m.CreatedAt,
                SentimentLabel = m.SentimentLabel,
                SentimentScore = m.SentimentScore,
            }).ToList();

            return Ok(messageDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessageAsync([FromBody] CreateMessageDto messageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var message = new Message
            {
                Content = messageDto.Content.Trim(),
                UserId = messageDto.UserId,
                CreatedAt = DateTime.UtcNow,
                SentimentLabel = messageDto.SentimentLabel,
                SentimentScore = messageDto.SentimentScore,
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            var createdMessageDto = new MessageDto
            {
                Id = message.Id,
                Content = message.Content,
                UserId = message.UserId,
                CreatedAt = message.CreatedAt,
                SentimentLabel = message.SentimentLabel,
                SentimentScore = message.SentimentScore,
            };

            return Ok(createdMessageDto);

        }
    }
}
