using MediPlus.DAL.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;

namespace MediPlus.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MediPlusDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"))
  );
            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
            app.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");
            

           app.Run();
        }
    }
}
