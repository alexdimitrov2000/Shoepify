using Shoepify.Data;
using Microsoft.EntityFrameworkCore;
using Shoepify.Domain;
using Microsoft.AspNetCore.Identity;
using Shoepify.Infrastructure.Extensions;
using Shoepify.Services.Contracts;
using Shoepify.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddDbContext<ShoepifyContext>(options =>
    options.UseLazyLoadingProxies()
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

services.AddDistributedMemoryCache();

services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1);
    options.Cookie.IsEssential = true;
});

services.AddControllersWithViews();

services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 2;
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
    })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ShoepifyContext>();

services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Administration/Administration/AccessDenied";
});

services.AddRazorPages();

// Register entity services
services.AddScoped<IColorsService, ColorsService>();
services.AddScoped<ISizesService, SizesService>();
services.AddScoped<ICategoriesService, CategoriesService>();
services.AddScoped<IShoesService, ShoesService>();

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.SeedRoles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller}/{action}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
