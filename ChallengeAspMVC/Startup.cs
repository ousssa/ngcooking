using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChallengeAspMVC.Startup))]
namespace ChallengeAspMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
