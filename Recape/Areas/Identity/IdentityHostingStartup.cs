[assembly: HostingStartup(typeof(Recape.Areas.Identity.IdentityHostingStartup))]
namespace Recape.Areas.Identity;

public class IdentityHostingStartup : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.ConfigureServices((context, services) =>
        {
        });
    }
}
