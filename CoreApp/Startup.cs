using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CoreApp.Data;
using CoreApp.Models;
using CoreApp.Models.AccountViewModels;
using CoreApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp
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
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
           
            //This is FacebookOAuth config routing.
              var facebookConfig = new OAuthSettings();
            Configuration.GetSection("FacebookOAuthSettings")
                .Bind(facebookConfig);
            services
                .AddAuthentication()
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = facebookConfig.AppId;
                    facebookOptions.AppSecret = facebookConfig.AppSecret;
                });
            
            //This is Google OAuth config routing.
            var googleConfig = new OAuthSettings();
            Configuration.GetSection("GoogleOAuthSettings")
                .Bind(googleConfig);
            services
                .AddAuthentication()
                .AddGoogle(googleOptions =>
                {
                     googleOptions.ClientId = googleConfig.ClientId;
                     googleOptions.ClientSecret = googleConfig.ClientSecret;
                });

            ////This is Charity  config routing.
            //var charityConfig = new APIsettings();
            //Configuration.GetSection("CharityAPISettings")
            //    .Bind(charityConfig);
            //services
            //    .(charityOptions =>
            //    {
            //        charityOptions.AppId = charityConfig.ClientId;
            //        charityOptions.ClientSecret = charityConfig.ClientSecret;
            //    });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Landing}/{id?}");
            });
        }
    }
}
