using Microsoft.EntityFrameworkCore;

namespace UrlShortener.Data
{
    public class UrlShortenerContext : DbContext
    {
        private string _connectionString;

        public UrlShortenerContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
    }
}