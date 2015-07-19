using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shorty.Web.Startup))]
namespace Shorty.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
