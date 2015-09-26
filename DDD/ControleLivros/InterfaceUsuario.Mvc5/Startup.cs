using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InterfaceUsuario.Mvc5.Startup))]
namespace InterfaceUsuario.Mvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
