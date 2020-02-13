using System.Data;
using System.Threading.Tasks;

namespace AppMetricsApi.Database
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync();

        Task SetupAsync();
    }
}