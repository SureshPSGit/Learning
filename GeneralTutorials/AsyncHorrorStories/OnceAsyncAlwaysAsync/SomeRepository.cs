using System.Threading.Tasks;

namespace OnceAsyncAlwaysAsync
{
    public class SomeRepository
    {
        public async Task<int> GetValueAsync()
        {
            return await Task.FromResult(1);
        }
    }
}
