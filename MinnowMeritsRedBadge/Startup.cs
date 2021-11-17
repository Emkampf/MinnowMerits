using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MinnowMeritsRedBadge.Startup))]
namespace MinnowMeritsRedBadge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
