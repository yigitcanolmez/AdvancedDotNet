namespace exampleOfMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Fenerbahçe GOLGOLGOL start");
            await next(context);
            await context.Response.WriteAsync("Şampppi end");
        }
    }
}

