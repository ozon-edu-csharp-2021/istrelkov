using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Ozon.MerchandiseServiceApi.Infrastructure.Middlewares;

namespace Ozon.MerchandiseServiceApi.Infrastructure.StartupFilters
{
    public class TerminalStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseMiddleware<RequestResponseLoggingMiddleware>();
                app.Map("/version", builder => builder.UseMiddleware<VersionMiddleware>());
                app.Map("/live", builder => builder.UseMiddleware<LiveMiddleware>());
                app.Map("/ready", builder => builder.UseMiddleware<ReadyMiddleware>());
                next(app);
            };
        }
    }
}