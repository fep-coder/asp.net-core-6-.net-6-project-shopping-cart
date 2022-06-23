using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Infrastructure;
using ShoppingCart.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
        options.UseSqlServer(builder.Configuration["ConnectionStrings:DbConnection"]);
});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
        options.IdleTimeout = TimeSpan.FromMinutes(30);
        options.Cookie.IsEssential = true;
});

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
        options.Password.RequiredLength = 4;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireDigit = false;

        options.User.RequireUniqueEmail = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
        app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Products}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "products",
    pattern: "/products/{categorySlug?}",
    defaults: new { controller = "Products", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);

app.Run();
