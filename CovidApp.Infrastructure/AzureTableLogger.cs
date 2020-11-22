using CovidApp.Infrastructure.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Threading.Tasks;

namespace CovidApp.Infrastructure
{
    public class AzureTableLogger : IAzureTableLogger
    {
        private readonly Settings _settings;

        public AzureTableLogger(Settings settings)
        {
            _settings = settings;
        }

        public async Task LogAsync(LogEntity log)
        {
            var storageAccount = CloudStorageAccount.Parse(_settings.Storage);
            var client = storageAccount.CreateCloudTableClient();
            var table = client.GetTableReference("HospitalLogs");
            await table.CreateIfNotExistsAsync();

            var operation = TableOperation.Insert(log);
            await table.ExecuteAsync(operation);
        }
    }

    public interface IAzureTableLogger
    {
        Task LogAsync(LogEntity log);
    }

    public class LogEntity : TableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}