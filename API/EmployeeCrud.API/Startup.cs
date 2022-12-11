using EmployeeCrud.API.Extensions;
using EmployeeCrud.DB;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.API
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void RegisterServices(IServiceCollection services)
        {
            var databaseConnectionString = configRoot["DatabaseConnectionString"];
            services.AddDbContext<EmployeeDBContext>(options =>

               options.UseSqlServer(
                   databaseConnectionString
               ), ServiceLifetime.Scoped
           );

            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddControllers().AddNewtonsoftJson();

            services.ConfigureSwaggerAPI();
            services.ConfigureWrapper();
            services.ConfigureJWToken();
        }
        public void SetupMiddlewares(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();
        }
    }
}

