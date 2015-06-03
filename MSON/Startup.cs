using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MSON.Startup))]
namespace MSON
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
