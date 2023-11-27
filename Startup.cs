using Microsoft.EntityFrameworkCore;
using finalproj.Models;
// Add this using statement
namespace finalproj
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; } // Ensure this property is defined at the class level


        public void ConfigureServices(IServiceCollection services)
        {
            // Add the DataContext service to the dependency injection container
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration["Data:FinalProj:ConnectionString"]);
            });

            // Add the DataImporter service to the dependency injection container as scoped
            services.AddScoped<IDataImporter, DataImporter>();

            // Add controllers with views
            services.AddControllersWithViews();
        }






        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
                context.Database.EnsureCreated();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // Seed data
            //SeedData(dbContext);
        }
    }
}
