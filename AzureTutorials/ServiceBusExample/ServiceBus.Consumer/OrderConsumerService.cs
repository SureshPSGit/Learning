using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace ServiceBus.Consumer
{
    public class OrderConsumerService : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}