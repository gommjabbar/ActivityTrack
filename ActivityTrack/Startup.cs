using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ActivityTrack.Startup))]
namespace ActivityTrack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
