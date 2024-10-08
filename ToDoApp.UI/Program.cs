using Microsoft.Extensions.FileProviders;
using ToDoApp.BussinessLayer.DependencyResolvers.Microsoft;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies();
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStatusCodePagesWithReExecute("/Home/NotFound", "?code={0}");

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
    RequestPath = "/node_modules"
});
app.MapDefaultControllerRoute();

app.Run();
