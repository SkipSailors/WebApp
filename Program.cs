using Microsoft.EntityFrameworkCore;
using WebApp.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:ProductConnection"]);
    opts.EnableSensitiveDataLogging();
});
builder.Services.AddControllersWithViews();
WebApplication app = builder.Build();
app.UseStaticFiles();
app.MapControllers();
app.MapDefaultControllerRoute();
DataContext context = app
    .Services
    .CreateScope()
    .ServiceProvider
    .GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);
app.Run();