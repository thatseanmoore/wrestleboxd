using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GolfTrack.WebMVC.Startup))]
namespace GolfTrack.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
