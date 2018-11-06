using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OwinMiddleWare.Startup))]

namespace OwinMiddleWare
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<LoggerMiddleware>();
        }
    }
}
