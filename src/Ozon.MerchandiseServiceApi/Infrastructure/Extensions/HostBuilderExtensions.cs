using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Ozon.MerchandiseServiceApi.Infrastructure.Filters;
using Ozon.MerchandiseServiceApi.Infrastructure.StartupFilters;

namespace Ozon.MerchandiseServiceApi.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
                
                services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo {Title = "Ozon.MerchandiseService", Version = "v1"});
                });
                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
               
            });
            return builder;
        }
    }
}