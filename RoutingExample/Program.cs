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
/*
 * constraint types kısıtlamak için kullanılır.
 * {employeeName:string} sadece stringleri kbul eder gibiiiiiiii
*   {employeeName:minlength(3)}
*   {employeeName:maxlength(7)}
*   {employeeName:length(3,9)}
*   {employeeName: length(3)} 3 olmalı
*   {age:min(12)} min 12
*   {age:max(72)} max 72
*   {age:range(12,72)}  12 72 arasında 
*   {name:alpha} A-Z, a-z olacak şekilde yazılabilir.

*/
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Could not found the page!");
});//özellikle belirttiğin istekler haricinde istek gelirse ne kullanmak istiyorsan ekleyebilirsin.

app.Run();
