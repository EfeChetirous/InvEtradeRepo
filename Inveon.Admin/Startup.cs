using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inveon.Admin.Startup))]
namespace Inveon.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
