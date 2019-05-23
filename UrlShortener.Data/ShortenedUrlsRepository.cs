using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace UrlShortener.Data
{
    public class ShortenedUrlsRepository
    {
        private readonly string _connectionString;

        public ShortenedUrlsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(ShortenedUrl url)
        {
            using (var context = new UrlShortenerContext(_connectionString))
            {
                context.ShortenedUrls.Add(url);
                context.SaveChanges();
            }
        }

        public ShortenedUrl GetByOriginalUrlForUser(string email, string originalUrl)
        {
            using (var context = new UrlShortenerContext(_connectionString))
            {
                return context.ShortenedUrls
                    .FirstOrDefault(u => u.OriginalUrl == originalUrl && u.User.Email == email);
            }
        }

        public ShortenedUrl GetByOriginalUrl(string originalUrl)
        {
            using (var context = new UrlShortenerContext(_connectionString))
            {
                return context.ShortenedUrls
                    .FirstOrDefault(u => u.OriginalUrl == originalUrl && u.UserId == null);
            }
        }

        public void AddView(int urlId)
        {
            using (var context = new UrlShortenerContext(_connectionString))
            {
                context.Database.ExecuteSqlCommand("UPDATE ShortenedUrls SET Views = Views + 1 WHERE Id = @id",
                    new SqlParameter("@id", urlId));
            }
        }

        public ShortenedUrl GetByHash(string hash)
        {
            using (var context = new UrlShortenerContext(_connectionString))
            {
                return context.ShortenedUrls
                    .FirstOrDefault(u => u.UrlHash == hash);
            }
        }

        public bool HashExists(string urlHash)
        {
            using (var context = new UrlShortenerContext(_connectionString))
            {
                return context.ShortenedUrls.Any(u => u.UrlHash == urlHash);
            }
        }

        public IEnumerable<ShortenedUrl> GetUrlsForUser(string email)
        {
            using (var context = new UrlShortenerContext(_connectionString))
            {
                return context.ShortenedUrls.Where(s => s.User.Email == email).ToList();
            }
        }
    }
}
