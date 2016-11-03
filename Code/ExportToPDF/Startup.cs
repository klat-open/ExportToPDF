using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Klat.Example.Startup))]
namespace Klat.Example
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
