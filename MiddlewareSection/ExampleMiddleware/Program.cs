WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("First Middleware!");

    await next(context);
});

app.Run(async (HttpContext context) => {

    await context.Response.WriteAsync("Merhaba!"); //app.run ile middleware yazılırsa, tek bir middleware olur doğal olarak altına başka bir app run ile middleware eklenirse çalışmaz
});
