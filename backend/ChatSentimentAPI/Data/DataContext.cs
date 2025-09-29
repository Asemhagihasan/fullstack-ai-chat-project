using ChatSentimentAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace ChatSentimentAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}
