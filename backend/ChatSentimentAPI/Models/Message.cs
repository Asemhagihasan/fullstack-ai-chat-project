using System.ComponentModel.DataAnnotations;

namespace ChatSentimentAPI.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Sentiment analysis results
        public string? SentimentLabel { get; set; }
        public double? SentimentScore { get; set; }

        // Navigation property
        public virtual User User { get; set; } = null!;
    }
}
