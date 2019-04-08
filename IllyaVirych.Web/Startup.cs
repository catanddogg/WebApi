using System;
using System.Threading.Tasks;
using IllyaVirych.Web.Hubs;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IllyaVirych.Web.Startup))]

namespace IllyaVirych.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR<ChatPersistentConnection>("/chat");
        }
    }
}
