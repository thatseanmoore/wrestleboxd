using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GolfTrack.Services.StartupOwin))]

namespace GolfTrack.Services
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
