using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VinylCollection.Data;
using VinylCollection.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VinylCollectionContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("VinylCollectionContext") ??
    throw new InvalidOperationException("Connection string 'VinylCollectionContext' not found."),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("VinylCollectionContext")), builder =>
    builder.MigrationsAssembly("VinylCollection")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<ArtistService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapWhen(context =>
{
    var env = context.RequestServices.GetRequiredService<IWebHostEnvironment>();

    if (env.IsDevelopment())
    {
        var seedingService = context.RequestServices.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }

    return false;
}, app => { });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
