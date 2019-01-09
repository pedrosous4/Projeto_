using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projeto_Stefanini.Web.Startup))]
namespace Projeto_Stefanini.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
