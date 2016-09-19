using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DameUnaIP.Startup))]
namespace DameUnaIP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
