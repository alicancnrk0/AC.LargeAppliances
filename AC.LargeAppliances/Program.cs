using AC.LargeAppliances.Models;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<EcomDbContext>(options =>
            {
                options.UseSqlServer("Server=127.0.0.1;User Id=sa;Password=11;Database=EcomDb;Encrypt=False;");
            });

            var app = builder.Build();

            app.UseStatusCodePages(async statusCodeContext =>
            {
                if (statusCodeContext.HttpContext.Response.StatusCode == 404)
                {
                    statusCodeContext.HttpContext.Response.Redirect("/Home/NotFoundPage");
                }
            });

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();


#pragma warning disable ASP0014

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Management",
                    areaName: "Management",
                    pattern: "Management/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            });

#pragma warning restore

            app.Run();
        }
    }
}
