using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeCheckInApp.Startup))]
namespace EmployeeCheckInApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
