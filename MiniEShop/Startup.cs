using Microsoft.Owin;
using MiniEShop;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace MiniEShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}