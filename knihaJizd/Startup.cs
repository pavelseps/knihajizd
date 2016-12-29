using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(knihaJizd.Startup))]
namespace knihaJizd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
