using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareApp.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomFromSctrachMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomFromSctrachMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            if (httpContext.Request.Query.ContainsKey("fistname") && httpContext.Request.Query.ContainsKey("lastname"))
            {
                string fullname = httpContext.Request.Query["fistname"] + " " + httpContext.Request.Query["lastname"];
                await httpContext.Response.WriteAsync(fullname);
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomFromSctrachMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomFromSctrachMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomFromSctrachMiddleware>();
        }
    }
}
