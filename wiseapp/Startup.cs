using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(wiseapp.Startup))]
namespace wiseapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
