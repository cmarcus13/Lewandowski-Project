using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lewandowski_Project.Startup))]
namespace Lewandowski_Project
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
