using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LewandowskiProject.Startup))]
namespace LewandowskiProject
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
