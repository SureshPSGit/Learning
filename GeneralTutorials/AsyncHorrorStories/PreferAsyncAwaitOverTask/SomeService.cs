using System.Threading.Tasks;

namespace PreferAsyncAwaitOverTask
{
    public class SomeService
    {
        public Task<int> GetValueAsync()
        {
            //Some IO call
            return Task.FromResult(1);
        }
    }
}
