using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JenkinsWebApplication.Startup))]
namespace JenkinsWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
