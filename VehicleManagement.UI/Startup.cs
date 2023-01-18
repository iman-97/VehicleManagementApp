using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VehicleManagement.UI.Startup))]
namespace VehicleManagement.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
