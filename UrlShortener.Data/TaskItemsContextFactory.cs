using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace UrlShortener.Data
{
    public class TaskItemsContextFactory : IDesignTimeDbContextFactory<UrlShortenerContext>
    {
        public UrlShortenerContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}UrlShortener.Web"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

            return new UrlShortenerContext(config.GetConnectionString("ConStr"));
        }
    }
}