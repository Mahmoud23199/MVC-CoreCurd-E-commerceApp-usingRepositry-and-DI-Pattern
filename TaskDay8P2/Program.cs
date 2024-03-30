using Microsoft.EntityFrameworkCore;
using TaskDay8P2.Models;
using TaskDay8P2.RepositoryServices;

namespace TaskDay8P2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MyDataBase")));

            builder.Services.AddScoped<ICustomerRepositry, CustomerRepositry>();
            builder.Services.AddScoped<IProductRepositry, ProductRepositry>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
