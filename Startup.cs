using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Capacitarte.Startup))]
namespace Capacitarte
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
