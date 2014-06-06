using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Prototype.Web.Startup))]
namespace Prototype.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
