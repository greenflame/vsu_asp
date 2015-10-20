using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(strpo_app.Startup))]
namespace strpo_app
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
