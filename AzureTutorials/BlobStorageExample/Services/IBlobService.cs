using System.Collections.Generic;
using System.Threading.Tasks;
using BlobStorageExample.Models;

namespace BlobStorageExample.Services
{
    public interface IBlobService
    {
        public Task<BlobInfo> GetBlobAsync(string name);

        public Task<IEnumerable<string>> ListBlobsAsync();

        public Task UploadBlobAsync(string filePath, string fileName);

        public Task DeleteBlobAsync(string blobName);
    }
}