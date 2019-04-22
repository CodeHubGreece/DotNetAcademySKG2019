using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Greenfield.Identity.Startup))]
namespace Greenfield.Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
