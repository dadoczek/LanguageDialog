using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AplikacjaLingwistyczna.Startup))]
namespace AplikacjaLingwistyczna
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
