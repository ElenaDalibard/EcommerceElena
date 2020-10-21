using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EcommerceElena.Startup))]
namespace EcommerceElena
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
