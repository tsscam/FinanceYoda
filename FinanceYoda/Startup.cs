using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinanceYoda.Startup))]
namespace FinanceYoda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
