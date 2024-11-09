using Microsoft.EntityFrameworkCore;
using Pustok.DAL.DataContexts;

namespace MiniProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddDalServices(builder.Configuration);


            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), builder => 
            builder.MigrationsAssembly(nameof(MiniProject))));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //using (var scope = app.Services.CreateScope())
            //{
            //    var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            //    await appDbContext.Database.MigrateAsync();
            //    //var dataInit=new DataInit(appDbContext);
            //    //await dataInit.SeedDataAsync();

            //}

            app.UseHttpsRedirection();
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
