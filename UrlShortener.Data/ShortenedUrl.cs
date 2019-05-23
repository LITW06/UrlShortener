namespace UrlShortener.Data
{
    public class ShortenedUrl
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string UrlHash { get; set; }
        public int? UserId { get; set; }
        public int Views { get; set; }

        public User User { get; set; }
    }
}