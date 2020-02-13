using App.Metrics;
using App.Metrics.Counter;

namespace AppMetricsApi
{
    public class MetricsRegistry
    {
        public static CounterOptions CreatedCustomersCounter => new CounterOptions
        {
            Name = "Created Customers",
            Context = "CustomersApi",
            MeasurementUnit = Unit.Calls
        };
        
        public static CounterOptions CreatedDbConnectionsCounter => new CounterOptions
        {
            Name = "Created Connections",
            Context = "Database",
            MeasurementUnit = Unit.Calls
        };
    }
}