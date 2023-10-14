using System;
namespace exampleOfMiddleware
{
	public static class UseExampleMiddleware 
	{
	
        public static IApplicationBuilder UseExampleOfMiddleware(this IApplicationBuilder app)
		{
            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                if (context.Request.Query.ContainsKey("firstName") && context.Request.Query.ContainsKey("lastName"))
                {
                    var write = context.Request.Query["firstName"] + " " + context.Request.Query["lastName"];
                    await context.Response.WriteAsync(write);
                }
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

