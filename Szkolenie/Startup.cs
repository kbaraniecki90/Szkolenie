using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Szkolenie.Startup))]
namespace Szkolenie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
