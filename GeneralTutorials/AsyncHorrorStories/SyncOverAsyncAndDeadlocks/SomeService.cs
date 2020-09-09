using System.Threading.Tasks;

namespace SyncOverAsyncAndDeadlocks
{
    public class SomeService
    {
        public async Task<int> GetValueAsync()
        {
            return await Task.FromResult(1);
        }
    }
}
