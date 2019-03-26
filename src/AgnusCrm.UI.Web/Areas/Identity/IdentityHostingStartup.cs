using System;
using AgnusCrm.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AgnusCrm.Areas.Identity.IdentityHostingStartup))]
namespace AgnusCrm.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddDbContext<ApplicationDbContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("AgnusCrmContext")));

                //services.AddDefaultIdentity<IdentityUser>(config =>
                //{
                //    config.SignIn.RequireConfirmedEmail = true;
                //})
                //    .AddEntityFrameworkStores<ApplicationDbContext>();
            });
            
        }
    }
}