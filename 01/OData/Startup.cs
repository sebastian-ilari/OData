using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OData.Startup))]
namespace OData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
