using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RiskRegisterII.Data;
using RiskRegisterII.ServiceHelper;
using RiskRegisterII.Services;

namespace RiskRegisterII
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().
                SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
                AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true).AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<RiskRegisterDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("RiskRegisterConnection")));

            // adding the required services here.
            services.AddScoped<IErrorRegister, ErrorRegisterService>((arg) => new ErrorRegisterService(services.BuildServiceProvider().GetRequiredService<RiskRegisterDbContext>()));
            services.AddScoped<IDepartment, DepartmentService>((arg) => new DepartmentService(services.BuildServiceProvider().GetRequiredService<RiskRegisterDbContext>()));
            services.AddScoped<ICompany, CompanyService>((arg) => new CompanyService(services.BuildServiceProvider().GetRequiredService<RiskRegisterDbContext>()));
            services.AddScoped<IRiskType, RiskTypeService>((arg) => new RiskTypeService(services.BuildServiceProvider().GetRequiredService<RiskRegisterDbContext>()));
            services.AddScoped<IComplaintRegister, ComplaintRegisterService>((arg) => new ComplaintRegisterService(services.BuildServiceProvider().GetRequiredService<RiskRegisterDbContext>()));
            services.AddScoped<IRegisterRisk, RegisterRiskService>((arg) => new RegisterRiskService(services.BuildServiceProvider().GetRequiredService<RiskRegisterDbContext>()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // adding the logger method.
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
