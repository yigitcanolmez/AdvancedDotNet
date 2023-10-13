using System;
namespace exampleOfMiddleware
{
	public static class UseExampleMiddleware 
	{
	
        public static IApplicationBuilder UseExampleOfMiddleware(this IApplicationBuilder app)
		{
            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                await context.Response.WriteAsync("First Middleware!");

                await next(context);
            });

            app.UseMiddleware<MyCustomMiddleware>();

            app.Run(async (HttpContext context) => {

                await context.Response.WriteAsync("Merhaba!"); //app.run ile middleware yazılırsa, tek bir middleware olur doğal olarak altına başka bir app run ile middleware eklenirse çalışmaz
            });
            return app;

		}

	}
}

