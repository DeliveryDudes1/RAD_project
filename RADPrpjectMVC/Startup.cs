using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RADPrpjectMVC.Startup))]
namespace RADPrpjectMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
