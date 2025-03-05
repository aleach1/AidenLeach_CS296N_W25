using CelesteMountain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CelesteMountain.Data;

var builder = WebApplication.CreateBuilder(args);


// Add MySQL support
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<CelesteMountainContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))/*, ServiceLifetime.Transient*/);



// Register the repository and repository interface
builder.Services.AddTransient<IStoryPostRepository, StoryPostRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add identity
builder.Services.AddIdentity<AppUser, IdentityRole>()
  .AddEntityFrameworkStores<CelesteMountainContext>()
  .AddDefaultTokenProviders();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//get DbContext seed data
using (var scope = app.Services.CreateScope())
{
    await SeedUsers.CreateAdminUser(scope.ServiceProvider);
    var dbContext = scope.ServiceProvider.GetRequiredService<CelesteMountainContext>();
    SeedData.Seed(dbContext, scope.ServiceProvider);

}

app.Run();