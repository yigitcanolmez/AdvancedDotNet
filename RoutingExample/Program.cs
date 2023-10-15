using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseRouting();//yönlendirme aktif, gelen isteğe göre en uygunu seçecektir.


app.Use(async (HttpContext context, RequestDelegate next) =>
{
    Endpoint? enpoint = context.GetEndpoint();//userouting kullanıldıktan sonra kullanılmalıdır. yönlendirme yapıldıktan sonra alabilir.

   
    await next(context);
});

app.UseEndpoints(endpoints =>
{//default değer de tanımlanabilmektedir, ekte göreceğiniz üzere.
    endpoints.Map("/file/{fileName=deneeme}/{extension?}", async (context) =>
    {
        
        await context.Response.WriteAsync($"{context.Request.RouteValues["fileName"]} {context.Request.RouteValues["extension"]}");
    });
    endpoints.MapPost("/map1", async (context) =>
    {
        await context.Response.WriteAsync("Hello from Map 1");
    });
    endpoints.MapPatch("/map2", async (context) =>
    {
        await context.Response.WriteAsync("Hello from Map 2");
    });
});//

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Could not found the page!");
});//özellikle belirttiğin istekler haricinde istek gelirse ne kullanmak istiyorsan ekleyebilirsin.

app.Run();
