using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Ozon.MerchandiseServiceApi.Infrastructure.Middlewares;
using Ozon.MerchandiseServiceApi.Services;
using Ozon.MerchandiseServiceApi.Services.Interfaces;

namespace Ozon.MerchandiseServiceApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMerchandiseService, MerchandiseService>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.Map("/version", builder => builder.UseMiddleware<VersionMiddleware>());
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}