using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvc_test.Startup))]
namespace mvc_test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
