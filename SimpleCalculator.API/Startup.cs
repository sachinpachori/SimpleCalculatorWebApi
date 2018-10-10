using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleCalculator.DataAccess;
using SimpleCalculator.Services;

namespace SimpleCalculator.API
{
    public class Startup
    {
        private readonly string sqlUserConnectionString;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            sqlUserConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddSingleton(Configuration);           
            

            services.AddDbContext<SimpleCalculatorAppContext>(options => options.UseSqlServer(sqlUserConnectionString));
        
            services.AddTransient<ISimpleCalculatorService, SimpleCalculatorService>();

            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddTransient<IDiagnosticsService, DiagnosticsService>();
                       
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        //This method gets called by the runtime.Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
                       
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                 name: "default",
                 template: "{controller=SimpleCalculator}/{action=Index}/{id?}/{id1?}/{id2?}");                
            });
        }
    }
}
