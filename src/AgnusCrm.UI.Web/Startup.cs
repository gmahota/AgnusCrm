using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgnusCrm.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;
using AgnusCrm.Services;
using AgnusCrm.Models;
using Microsoft.Extensions.Logging;
using Site.Middlewares;
using Site.Extensions;

namespace AgnusCrm
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("AgnusCrmContext")));
            
            //// Get Identity Default Options
            IConfigurationSection identityDefaultOptionsConfigurationSection = Configuration.GetSection("IdentityDefaultOptions");

           services.Configure<IdentityDefaultOptions>(identityDefaultOptionsConfigurationSection);

            var identityDefaultOptions = identityDefaultOptionsConfigurationSection.Get<IdentityDefaultOptions>();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Password settings
                options.Password.RequireDigit = identityDefaultOptions.PasswordRequireDigit;
                options.Password.RequiredLength = identityDefaultOptions.PasswordRequiredLength;
                options.Password.RequireNonAlphanumeric = identityDefaultOptions.PasswordRequireNonAlphanumeric;
                options.Password.RequireUppercase = identityDefaultOptions.PasswordRequireUppercase;
                options.Password.RequireLowercase = identityDefaultOptions.PasswordRequireLowercase;
                options.Password.RequiredUniqueChars = identityDefaultOptions.PasswordRequiredUniqueChars;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(identityDefaultOptions.LockoutDefaultLockoutTimeSpanInMinutes);
                options.Lockout.MaxFailedAccessAttempts = identityDefaultOptions.LockoutMaxFailedAccessAttempts;
                options.Lockout.AllowedForNewUsers = identityDefaultOptions.LockoutAllowedForNewUsers;

                // User settings
                options.User.RequireUniqueEmail = identityDefaultOptions.UserRequireUniqueEmail;

                // email confirmation require
                options.SignIn.RequireConfirmedEmail = identityDefaultOptions.SignInRequireConfirmedEmail;
            }).AddDefaultUI(UIFramework.Bootstrap4)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            // Add custom role services
            services.AddTransient<IRoles, Roles>();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            //services.AddSingleton<IEmailSender, EmailSender>();

            // Add DI for Dotnetdesk
            services.AddTransient<IAgnusCrmService, AgnusCrmService>();

            // Get SendGrid configuration options
            services.Configure<SendGridOptions>(Configuration.GetSection("SendGridOptions"));

            // Get SMTP configuration options
            services.Configure<SmtpOptions>(Configuration.GetSection("SmtpOptions"));
            
            // Get Super Admin Default options
            services.Configure<SuperAdminDefaultOptions>(Configuration.GetSection("SuperAdminDefaultOptions"));

            services.AddMvc(options =>
            {
                //options.Filters.Add(new ServiceFilterAttribute(typeof(ActionLogger)));
            });

            services.AddDependencyInjection();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            #region Logging

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            #endregion

            #region Enviroment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/AspNetCore-hsts.
                app.UseHsts();
            }
            #endregion

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseRequestCulture();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{culture=en-US}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
