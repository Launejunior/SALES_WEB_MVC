using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SALES_WEB_MVC.Data;
using SALES_WEB_MVC.Models;
using SALES_WEB_MVC.Services;

namespace SALES_WEB_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SALES_WEB_MVCContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SALES_WEB_MVCContext") ?? throw new InvalidOperationException("Connection string 'SALES_WEB_MVCContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<SellerVendedorService>();
            builder.Services.AddScoped<DepartamentoService>();


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

            //AQUI CHAMA O MÉTODO SEED()
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<SALES_WEB_MVCContext>();
                var seedingService = services.GetRequiredService<SeedingService>();
                seedingService.Seed();
            }


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
