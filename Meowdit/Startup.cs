using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Meowdit.Startup))]
namespace Meowdit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
