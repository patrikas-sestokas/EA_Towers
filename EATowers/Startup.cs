using EATowers.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EATowers
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddCors(options =>
                options.AddDefaultPolicy(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4000").AllowCredentials()));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Error");
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseEndpoints(endpoints => endpoints.MapHub<CommHub>("/commHub"));
        }
    }
}