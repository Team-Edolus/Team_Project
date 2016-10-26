using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EdolusApp.Startup))]
namespace EdolusApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
