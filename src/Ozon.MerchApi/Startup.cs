using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Ozon.MerchApi.Infrastructure.Middlewares;
using Ozon.MerchApi.GrpcServices;
using Ozon.MerchApi.Infrastructure.Interceptors;
using Ozon.MerchApi.Services;
using Ozon.MerchApi.Services.Interfaces;

namespace Ozon.MerchApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMerchandiseService, MerchandiseService>();
            services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<MerchApiGrpsService>();
                endpoints.MapControllers();
            });
        }
    }
}