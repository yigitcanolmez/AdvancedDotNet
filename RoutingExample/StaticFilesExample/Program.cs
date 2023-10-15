using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "myRoot"
});
var app = builder.Build();

app.UseStaticFiles();//myRoot

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "myWebRoot"))
});

//http://localhost:5175/ocelot.png şeklinde yazarsan static file açılır:)))))))
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async (context) =>
    {
        context.Response.WriteAsync("Hello");
    });
});
app.Run();

