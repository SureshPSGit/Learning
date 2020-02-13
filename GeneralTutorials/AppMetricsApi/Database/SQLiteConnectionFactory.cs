using System.Data;
using System.IO;
using System.Threading.Tasks;
using App.Metrics;
using Dapper;
using Microsoft.Data.Sqlite;

namespace AppMetricsApi.Database
{
    public class SqLiteConnectionFactory : IDbConnectionFactory
    {
        private readonly string _dbLocation;
        private readonly IMetrics _metrics;
        
        public SqLiteConnectionFactory(string dbLocation, IMetrics metrics)
        {
            _dbLocation = dbLocation;
            _metrics = metrics;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new SqliteConnection($"Data Source={_dbLocation}");
            _metrics.Measure.Counter.Increment(MetricsRegistry.CreatedDbConnectionsCounter);
            await connection.OpenAsync();
            return connection;
        }

        public async Task SetupAsync()
        {
            if (!File.Exists(_dbLocation))
            {
                File.Create(_dbLocation).Close();
                using var connection = await CreateConnectionAsync();
                await connection.ExecuteAsync("CREATE TABLE Customers (Id TEXT PRIMARY KEY NOT NULL, FullName TEXT NOT NULL);");
            }
        }
    }
}