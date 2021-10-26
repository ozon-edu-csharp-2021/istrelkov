using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ozon.MerchandiseServiceApi.Infrastructure.Middlewares
{
    public class VersionMiddleware
    { 
        private readonly RequestDelegate _next;
        public VersionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version";
            await context.Response.WriteAsync(version);
            await _next.Invoke(context);
        }
        
    }
}