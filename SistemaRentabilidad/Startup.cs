using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaRentabilidad.Startup))]
namespace SistemaRentabilidad
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
