using CrmFacadeApi.Repository;
using CrmFacadeApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


//using CrmFacadeApi.Domain.Repositories;
//using CrmFacadeApi.Domain.Services;
//using CrmFacadeApi.Persistence.Repositories;
//using CrmFacadeApi.Persistence.Contexts;

namespace CrmFacadeApi
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    options.UseInMemoryDatabase("CrmFacadeApi-in-memory");
            //});





            services.AddControllers();
            services.AddScoped<IHealthCheckService, HealthCheckService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAddressVerificationService, AddressVerificationService>();
            services.AddScoped<ICrmRepository, CrmRepository>();
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
