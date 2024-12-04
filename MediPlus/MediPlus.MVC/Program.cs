using MediPlus.BL.Services.Abstractions;
using MediPlus.BL.Services.Concretes;
using MediPlus.DAL.Contexts;
using MediPlus.DAL.Migrations;
using MediPlus.DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace MediPlus.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 4;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredUniqueChars = 2;
                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._ ";

            }).AddDefaultTokenProviders().AddEntityFrameworkStores<MediPlusDbContext>();
            builder.Services.AddDbContext<MediPlusDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql")));
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
     
    }
}
