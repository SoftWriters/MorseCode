using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MorseCodeMVC.Startup))]
namespace MorseCodeMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
