using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssignmentAppDev2021.Startup))]
namespace AssignmentAppDev2021
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
