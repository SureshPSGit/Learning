using System.Threading.Tasks;

namespace PreferAwaitOverContinueWith
{
    public class SomeService
    {
        public async Task<int> GetValueAsync()
        {
            return await Task.FromResult(1);
        }
    }
}
