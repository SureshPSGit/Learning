using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisTutorial.Services
{
    public interface ICacheService
    {
        Task<string> GetCacheValueAsync(string key);

        Task SetCacheValueAsync(string key, string value);
    }
}