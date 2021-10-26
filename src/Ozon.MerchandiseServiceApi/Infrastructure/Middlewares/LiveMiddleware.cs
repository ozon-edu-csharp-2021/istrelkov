using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ozon.MerchandiseServiceApi.Infrastructure.Middlewares
{
    public class LiveMiddleware
    {
        private readonly RequestDelegate _next;
        public LiveMiddleware(RequestDelegate next)
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