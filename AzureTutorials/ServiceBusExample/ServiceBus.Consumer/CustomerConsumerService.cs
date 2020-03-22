using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace ServiceBus.Consumer
{
    public class CustomerConsumerService : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}