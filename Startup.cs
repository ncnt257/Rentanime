using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rentanime.Startup))]
namespace Rentanime
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
