using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Walk.Startup))]
namespace Walk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
