using BulkyBookWeb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = 
    builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AplicationDBContext>(options =>   //registers the AplicationDBContext with the DI container.
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));//The options parameter is configured to use SQL Server as the database provider, and it retrieves the connection string named DefaultConnection from the configuration file (e.g., appsettings.json).


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
