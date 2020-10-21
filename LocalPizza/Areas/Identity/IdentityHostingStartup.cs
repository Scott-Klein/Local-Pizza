using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(LocalPizza.Areas.Identity.IdentityHostingStartup))]

namespace LocalPizza.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}