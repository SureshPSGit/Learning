using App.Metrics;
using App.Metrics.Internal;
using AppMetricsApi.Database;
using AppMetricsApi.Repositories;
using AppMetricsApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AppMetricsApi
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
            services.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });
            services.AddMetrics();
            services.AddLogging();
            services.AddControllers();
            services.AddSingleton<ILoggingService, TestableLogger>();
            services.AddSingleton<IDbConnectionFactory>(x =>
                new SqLiteConnectionFactory(Configuration.GetValue<string>("Database:DbLocation"), 
                    x.GetRequiredService<IMetrics>()));
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<ICustomerService, CustomerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
