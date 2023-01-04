using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SAASystem.Context;
using SAASystem.Context.Interface;

namespace SAASystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDataProtection();
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IApartmentContext, ApartmentContext>();
            services.AddScoped<IContractContext, ContractContext>();
            services.AddScoped<IEmployeeContext, EmployeeContext>();
            services.AddScoped<IPropertyContext, PropertyContext>();
            services.AddScoped<IRoleContext, RoleContext>();
            services.AddScoped<IRoomContext, RoomContext>();
            services.AddScoped<IStockContext, StockContext>();
            services.AddScoped<ISuiteContext, SuiteContext>();
            services.AddScoped<ITenantContext, TenantContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });
        }
    }
}
