var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Request.Headers["Access-Control-Allow-Origin"] = "asd12";
    context.Response.Headers["KEY"] = "VALUE";
    context.Response.Headers["Server"] = "Heyyo";
    context.Response.Headers["Date"] = "Manipulating";
    context.Response.Headers["Content-Type"] = "text/html";
    context.Response.StatusCode = StatusCodes.Status200OK;
    await context.Response.WriteAsync("<h1><b>YIQIDO</b></h1>");
    await context.Response.WriteAsync("<h2><b>ASPO</b></h2>");
    await context.Response.WriteAsync("<h3><b>DENO</b></h3>");


});

app.Run();
