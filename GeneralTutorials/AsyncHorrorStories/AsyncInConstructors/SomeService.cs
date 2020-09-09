using System.Threading.Tasks;

namespace AsyncInConstructors
{
    public class SomeService
    {
        private readonly MyConnection _myConnection;

        private SomeService(MyConnection myConnection)
        {
            _myConnection = myConnection;
        }

        public async Task<int> GetValueAsync()
        {
            return await Task.FromResult(1);
        }

        public static async Task<SomeService> CreateAsync(ConnectionFactory factory)
        {
            return new SomeService(await factory.CreateConnectionAsync());
        }
    }
}
