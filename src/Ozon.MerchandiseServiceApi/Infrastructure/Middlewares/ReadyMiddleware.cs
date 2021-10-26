using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ozon.MerchandiseServiceApi.Infrastructure.Middlewares
{
    public class ReadyMiddleware
    {
        private readonly RequestDelegate _next;
        public ReadyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Clear();
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            await context.Response.WriteAsync("");
        }

    }
}