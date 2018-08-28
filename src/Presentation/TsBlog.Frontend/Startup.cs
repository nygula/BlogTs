using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TsBlog.Frontend.Startup))]
namespace TsBlog.Frontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
