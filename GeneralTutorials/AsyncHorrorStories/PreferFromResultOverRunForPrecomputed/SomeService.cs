using System.Threading.Tasks;

namespace PreferFromResultOverRunForPrecomputed
{
    public class SomeService
    {
        public async ValueTask<int> GetValueAsync(int numberToAdd)
        {
            return await new ValueTask<int>(numberToAdd * 2);
        }
    }
}
