using Microsoft.EntityFrameworkCore;
using finalproj.Models; // Add this using statement
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
            // Uncomment the following lines to configure the database context
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration["Data:FinalProj:ConnectionString"]));

            services.AddControllersWithViews();
        }

       

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
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
