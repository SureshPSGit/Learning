using System.Threading.Tasks;

namespace AsyncInConstructors
{
    public class ConnectionFactory
    {
        public async Task<MyConnection> CreateConnectionAsync()
        {
            return await Task.FromResult(new MyConnection());
        }
    }

    public class MyConnection {}
}
