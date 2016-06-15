using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistEduc.Startup))]
namespace SistEduc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
