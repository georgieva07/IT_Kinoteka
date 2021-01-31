using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kinoteka.Startup))]
namespace Kinoteka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
