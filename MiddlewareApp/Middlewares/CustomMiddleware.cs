namespace MiddlewareApp.Middlewares
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("<p>My Custom Middleware - Starts</p>");
            await next(context);
            await context.Response.WriteAsync("<p>My Custom Middleware - Ends</p>");
        }
    }

  


}
