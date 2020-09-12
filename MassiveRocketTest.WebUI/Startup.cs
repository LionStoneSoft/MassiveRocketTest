using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MassiveRocketTest.WebUI.Startup))]
namespace MassiveRocketTest.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
