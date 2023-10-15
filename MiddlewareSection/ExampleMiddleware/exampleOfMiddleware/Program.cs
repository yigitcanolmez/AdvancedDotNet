using exampleOfMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();

app.UseWhen(

    context => context.Request.Query.ContainsKey("hello"),
    app =>{
        app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("HELLLOO");
        await next();
    });
    }

);

app.UseExampleOfMiddleware();

app.Run();














