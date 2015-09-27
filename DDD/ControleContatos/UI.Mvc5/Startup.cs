using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UI.Mvc5.Startup))]
namespace UI.Mvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
