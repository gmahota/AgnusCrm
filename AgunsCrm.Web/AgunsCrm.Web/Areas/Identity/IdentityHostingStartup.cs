using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(AgnusCrm.Web.Areas.Identity.IdentityHostingStartup))]
namespace AgnusCrm.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {

            });
        }
    }
}