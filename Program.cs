
using Microsoft.EntityFrameworkCore;
using PSA_MVC_V2.Models.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PSADB>(i => i.UseSqlServer("Server=78.60.99.137;Database=master;user id=superDuper;password=labaislaptaskodas;Trusted_Connection=False;"));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
