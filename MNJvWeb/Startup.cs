using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MNJvWeb.Startup))]
namespace MNJvWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
