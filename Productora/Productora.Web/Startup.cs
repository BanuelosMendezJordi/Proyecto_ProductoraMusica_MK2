using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Productora.Web.Startup))]
namespace Productora.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
