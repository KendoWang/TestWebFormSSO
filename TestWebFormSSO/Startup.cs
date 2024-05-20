using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestWebFormSSO.Startup))]
namespace TestWebFormSSO
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
