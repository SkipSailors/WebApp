using Microsoft.EntityFrameworkCore;
using WebApp.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:ProductConnection"]);
    opts.EnableSensitiveDataLogging();
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<CityData>();
WebApplication app = builder.Build();
app.UseStaticFiles();
app.MapControllers();
app.MapDefaultControllerRoute();
app.MapRazorPages();
DataContext context = app
    .Services
    .CreateScope()
    .ServiceProvider
    .GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);
app.Run();