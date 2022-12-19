
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL.Design;
using Microsoft.Extensions.Options;
using EvlerKiralik.DAL.Entities;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication;

namespace EvlerKiralik
{
    public class Program
    {
     
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddEntityFrameworkNpgsql().AddDbContext<PostgresContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "EvlerKiralik.Auth";
                options.LoginPath = "/Home/Tabpage";
               // options.AccessDeniedPath = "/Login/Index";
            });
            builder.Services.AddMvc().AddSessionStateTempDataProvider();
            builder.Services.AddSession();
            //builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddHttpContextAccessor();
           // builder.Services.AddDistributedMemoryCache();



          
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
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCookiePolicy();
         
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            
        }
       

    } }