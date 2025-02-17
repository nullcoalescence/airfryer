using airfryer.Db;
using Microsoft.EntityFrameworkCore;

namespace airfryer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Config
            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            
            // Add services to the container.
            builder.Services.AddRazorPages();
            
            // Db
            builder.Services.AddDbContext<AirfryerContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
                .WithStaticAssets();
            
            // If appsettings has 'RunMigrations' = true, grab context from service scope and run migrations
            // TODO might want to have a pipeline do this in the future, but this makes it easy for running migrations in dev build docker container
            if (builder.Configuration.GetValue<bool>("RunMigrations"))
            {
                using (var serviceScope = app.Services.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<AirfryerContext>();
                    context.Database.Migrate();
                }
            }
            
            app.Run();
        }
    }
}