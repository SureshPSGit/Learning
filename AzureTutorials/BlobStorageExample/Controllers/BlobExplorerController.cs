using System.Threading.Tasks;
using BlobStorageExample.Models;
using BlobStorageExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlobStorageExample.Controllers
{
    [Route("blobs")]
    public class BlobExplorerController : Controller
    {
        private readonly IBlobService _blobService;
        
        public BlobExplorerController(IBlobService blobService)
        {
            _blobService = blobService;
        }
        
        [HttpGet("{blobName}")]
        public async Task<IActionResult> GetBlob(string blobName)
        {
            var data = await _blobService.GetBlobAsync(blobName);
            return File(data.Content, data.ContentType);
        }

        [HttpGet("")]
        public async Task<IActionResult> ListBlobs()
        {
            return Ok(await _blobService.ListBlobsAsync());
        }

        [HttpPost("")]
        public async Task<IActionResult> UploadFile([FromBody] UploadFileRequest request)
        {
            await _blobService.UploadBlobAsync(request.FilePath, request.FileName);
            return Ok();
        }

        [HttpDelete("{blobName}")]
        public async Task<IActionResult> DeleteFile(string blobName)
        {
            await _blobService.DeleteBlobAsync(blobName);
            return Ok();
        }
    }
}