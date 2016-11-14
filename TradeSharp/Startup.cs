using Microsoft.Owin;
using Owin;
using TradeSharp;

[assembly: OwinStartup(typeof(Startup))]

namespace TradeSharp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}