namespace ChatSentimentAPI.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? SentimentLabel { get; set; }
        public double? SentimentScore { get; set; }
    }
}
