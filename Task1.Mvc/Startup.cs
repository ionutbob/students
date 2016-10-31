using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Task1.Mvc.Startup))]
namespace Task1.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
