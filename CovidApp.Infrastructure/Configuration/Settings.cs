using Microsoft.Extensions.Configuration;

namespace CovidApp.Infrastructure.Configuration
{
    public class Settings
    {
        private readonly IConfiguration _configuration;
        public Settings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Storage => _configuration.GetConnectionString("Storage");
        public string BlobUrl => _configuration.GetConnectionString("BlobUrl");
    }
}