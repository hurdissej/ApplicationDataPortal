using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApplicationDataPortal.Startup))]
namespace ApplicationDataPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
