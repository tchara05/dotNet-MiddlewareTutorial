using MiddlewareApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<CustomMiddleware>();
builder.Services.AddTransient<CustomMiddleware2>();

// You do not need this when you create middleware from template class
// builder.Services.AddTransient<CustomFromSctrachMiddleware>();


var app = builder.Build();



/** 
 * 
 * 
 * Recommended Way of using the building default Middleware from MS
 * 
 * 
 **/


app.UseExceptionHandler("Error");
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllers();


/** 
 * 
 * 
 * Our Inline middlewares or Custom Middlewares
 * 
 * 
 **/




// Using Run you cannot create chain of middlewares

// app.Run( async (HttpContext context) => {
//    await context.Response.WriteAsync("Hello");
// });




// To Create Chain of middlewares you need to use the USE() method with 2 parameters. 


// Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) => {
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync("<p>Middleware 1<p>");

    await next(context); // proceeds to the next middleware. 
});


// Custom Middleware Implementing the Middleware Internafe
app.UseMiddleware<CustomMiddleware>();

// Custom Middleware 2 Middleware Internafe with injection/extension 
app.UseCustomMiddleware2();

// Custom Middleware (Middleware Template Class) 2 with  injection/extension
app.UseCustomFromSctrachMiddleware();

// Middleware 3
app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("<p>Middleware 3</p>");
});



//app.Run();