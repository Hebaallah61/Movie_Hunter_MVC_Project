using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoClasses;
using Movie_Hunter_FinalProject.RepoInterface;
using System;

namespace Movie_Hunter_FinalProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("ApplicationContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationContextConnection' not found.");

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<SystemUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationContext>();

            builder.Services.AddScoped<IGenericRepo<Movies>, MovieRepo>();
            builder.Services.AddScoped<IGenericRepo<Series>, SeriesRepo>();
            builder.Services.AddScoped<IGenericRepo<Episodes>, EpisodeRepo>();
            builder.Services.AddScoped<IGenericRepo<LookUpTable>, LookUpTableRepo>();
            builder.Services.AddScoped<ILookValueRepo, LookUpValuesRepo>();
            builder.Services.AddScoped<IUserSeriesRepo , UserSeriesRepo>();
            builder.Services.AddScoped<IUserMovieRepo, UserMoviesRepo>();
            builder.Services.AddScoped<IUserEpisodeRepo,UserEpisodeRepo>();

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
            app.MapAreaControllerRoute(
                name: "default2",
                areaName: "User",
                pattern: "{controller=UserMoviesWatch}/{action=Index}"
                );
          app.MapControllerRoute(
             name: "defaultWithArea",
             pattern: "{area:exists}/{controller=Home}/{action=Index}"
         );
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}