using System.Runtime.CompilerServices;

namespace MiddlewareApp.Middlewares
{
    public class CustomMiddleware2 : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("<p>My Custom Middleware 2 - Starts</p>");
            await next(context);
            await context.Response.WriteAsync("<p>My Custom Middleware 2- Ends</p>");
        }
    }


    // Injecting it to the app object to use more clearly. 
    public static class CustomMiddleware2Extension
    {
        public static IApplicationBuilder UseCustomMiddleware2(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware2>();
        }
    }

}
