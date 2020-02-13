using System.Threading.Tasks;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;
using AppMetricsApi.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AppMetricsApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var connectionFactory = serviceScope.ServiceProvider.GetRequiredService<IDbConnectionFactory>();
                await connectionFactory.SetupAsync();
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseMetricsWebTracking()
                .UseMetrics(options => { options.EndpointOptions = endpointsOptions =>
                {
                    endpointsOptions.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
                    endpointsOptions.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
                    endpointsOptions.EnvironmentInfoEndpointEnabled = false;
                }; })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
