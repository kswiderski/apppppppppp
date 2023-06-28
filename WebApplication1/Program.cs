using Microsoft.EntityFrameworkCore;
using WebApplication1.Persistence;
using WebApplication1.Services.Customers;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllersWithViews();

services.AddScoped<ICustomerService, CustomerService>();

services.AddDbContext<DatabaseContext>(
    options => options.UseNpgsql("Server=localhost;Port=5432;database=test;uid=postgres;pwd=password;"));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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