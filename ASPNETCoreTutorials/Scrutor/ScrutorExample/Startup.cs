using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScrutorExample.Extensions;
using ScrutorExample.Mapping;
using ScrutorExample.PipelineBehaviors;
using ScrutorExample.Repositories;
using ScrutorExample.Repositories.Cached;
using ScrutorExample.Services;

namespace ScrutorExample
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
            services.AddControllers();

            services.AddSingleton<ICustomersRepository, CustomersRepository>();
            services.Decorate<ICustomersRepository, CachedCustomersRepository>();
            
            services.AddSingleton<IOrdersRepository, OrdersRepository>();
            
            services.AddSingleton<IMapper, Mapper>();
            
            services.AddMediatR(typeof(Startup));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
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

            app.UseFluentValidationExceptionHandler();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}