using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Fluxor;
using Blazor.Fluxor.ReduxDevTools;
using Blazor.Fluxor.Routing;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServerBlazor.Authorization;
using ServerBlazor.Data;
using ServerBlazor.Services;

namespace ServerBlazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("DataSource=app.db"));
            
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();
            
            services.AddRazorPages();
            services.AddServerSideBlazor();
            //services.AddSignalR().AddAzureSignalR();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy => 
                    policy.AddRequirements(new EmailRequirement("admin.com")));
            });

            services.AddSingleton<IAuthorizationHandler, EmailAuthHandler>();
            
            services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
            services.AddSingleton<WeatherForecastService>();
            services.AddScoped<RandomService>();

            services.AddBlazoredLocalStorage();
            services.AddBlazoredSessionStorage();
            services.AddScoped<VisitTrackingService>();

            services.AddFluxor(options =>
            {
                options.UseDependencyInjection(typeof(Startup).Assembly);
                options.AddMiddleware<ReduxDevToolsMiddleware>();
                options.AddMiddleware<RoutingMiddleware>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
