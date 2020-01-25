using System.Data;
using System.Threading.Tasks;

namespace CustomersApi.Database
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync();

        Task SetupAsync();
    }
}