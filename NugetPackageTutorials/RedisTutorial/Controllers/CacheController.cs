using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedisTutorial.Contracts;
using RedisTutorial.Services;

namespace RedisTutorial.Controllers
{
    public class CacheController : ControllerBase
    {
        private readonly ICacheService _cacheService;
        
        public CacheController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        
        [HttpGet("cache/{key}")]
        public async Task<IActionResult> GetCacheValue([FromRoute] string key)
        {
            var value = await _cacheService.GetCacheValueAsync(key);
            return string.IsNullOrEmpty(value) ? (IActionResult) NotFound() : Ok(value);
        }
        
        [HttpPost("cache")]
        public async Task<IActionResult> GetCacheValue([FromBody] NewCacheEntryRequest request)
        {
            await _cacheService.SetCacheValueAsync(request.Key, request.Value);
            return CreatedAtAction("GetCacheValue", request.Value);
        }
    }
}