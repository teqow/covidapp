using CovidApp.Infrastructure.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CovidApp.Infrastructure
{
    public interface IBlobStorageProvider
    {
        Task<string> UploadFile(IFormFile file);
    }

    public class BlobStorageProvider : IBlobStorageProvider
    {
        private readonly Settings _settings;

        public BlobStorageProvider(Settings settings)
        {
            _settings = settings;
        }

        private async Task<CloudBlobContainer> GetCloudBlobContainer()
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(_settings.Storage);
            CloudBlobClient blobClient = account.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("patients");
            await container.CreateIfNotExistsAsync();
            return container;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            CloudBlobContainer container = await GetCloudBlobContainer();
            string blobName = Guid.NewGuid().ToString().ToLower().Replace("-", String.Empty);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
            blockBlob.Properties.ContentType = "image/jpg";
            
            using(var stream = file.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(stream);
            }

            return blockBlob.Uri.ToString();
        }
    }
}