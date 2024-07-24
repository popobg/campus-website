using CampusApp.Data;
using CampusApp.Interface;
using CampusApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CampusApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container: builder's configuration;
            // always before building the app.
            builder.Services.AddControllersWithViews();

            // dependancy injection to create our DbContext ==> create DB
            builder.Services.AddDbContext<CampusDbContext>(options =>
            {
                // specify the DBMS (`UseSqlServer` here)
                // Specify the name of the connection string that is in the appsettings.json,
                // which will be the name of the created DB
                options.UseSqlServer(builder.Configuration.GetConnectionString("CampusDb"));
            });

            // Local repo and datas
            //builder.Services.AddScoped<IStudentRepository, StudentLocalRepository>();
            //builder.Services.AddScoped<ICourseRepository, CourseLocalRepository>();

            // SQL DB
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Allows the use of CSS and JS file (wwwroot)
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
