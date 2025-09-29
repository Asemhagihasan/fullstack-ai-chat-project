using System.ComponentModel.DataAnnotations;

namespace ChatSentimentAPI.DTOs
{
    public class CreateMessageDto
    {
        [Required(ErrorMessage = "Message content is required")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Message must be between 1 and 1000 characters")]
        public string Content { get; set; } = "";

        [Required(ErrorMessage = "User ID is required")]
        public int UserId { get; set; }
        public string? SentimentLabel { get; set; }
        public double? SentimentScore { get; set; }

    }
}
