using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Hypercent.Wings.Startup))]
namespace Hypercent.Wings
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
