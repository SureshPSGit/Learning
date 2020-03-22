using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceBus.Consumer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<CustomerConsumerService>();
            services.AddSingleton<ISubscriptionClient>(x =>
                new SubscriptionClient(Configuration.GetValue<string>("ServiceBus:ConnectionString"),
                    Configuration.GetValue<string>("ServiceBus:TopicName"),
                    Configuration.GetValue<string>("ServiceBus:SubscriptionName")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}