using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExportToPDF.Startup))]
namespace ExportToPDF
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
