using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureKeyVaultExample.Models;
using Cosmonaut;
using Cosmonaut.Extensions.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AzureKeyVaultExample
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
            var dbSettings = new DatabaseSettings();
            Configuration.Bind(nameof(DatabaseSettings), dbSettings);
            var cosmosStoreSettings = new CosmosStoreSettings(dbSettings.DatabaseName, dbSettings.DatabaseUrl, dbSettings.DatabaseKey, 
                new ConnectionPolicy{ConnectionMode = ConnectionMode.Direct, ConnectionProtocol = Protocol.Tcp});
            services.AddCosmosStore<Customer>(cosmosStoreSettings);
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

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}