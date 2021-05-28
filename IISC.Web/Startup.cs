using Garage.Core.AppDbContext;
using Garage.Core.Repository;
using Garage.Core.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISC.Web
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
            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options => {
                options.LoginPath = "/Login";
                options.LogoutPath = "/Signout";
                options.AccessDeniedPath = "/AccessDenied";
            });

            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizePage("/Login");
            });

            //Database connection
            services.AddDbContextPool<GarageDbContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("GarageDbConn")));
            services.AddScoped<ICategoryRepository, CategoryService>();
            services.AddScoped<IRoutineRepository, RoutineService>();
            services.AddScoped<INavigationRepository, NavigationService>();
            services.AddScoped<IAssetRepository, AssetService>();
            services.AddScoped<ILogSheetRepository, LogSheetService>();
            services.AddScoped<ITransaction, TransactionService>();
            services.AddScoped<IDashboardRepository, DashboardService>();
            services.AddScoped<IAxAutoMobileRepository, AxAutoMobileService>();
            services.AddScoped<IAccountRepository, AccountService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //loggerFactory.AddFile("Logs/mylog-{Date}.txt");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
