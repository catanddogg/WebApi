using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IllyaVirych.Web.Core.ChatsSignalR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin.Builder;
using Owin;

namespace IllyaVirych.Web.Core
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR<ChatPersistentConnection>("/chat");
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            ////app.UseOwin(addToPipeline =>
            ////{
            ////    addToPipeline(next =>
            ////    {
            ////        var appBuilder = new AppBuilder();
            ////        appBuilder.Properties["builder.DefaultApp"] = next;
            ////        appBuilder.MapSignalR();                    
            ////        return appBuilder.Build<ChatPersistentConnection>();
            ////    });
            ////});

            //app.UseSignalR(routes =>
            //{
            //    routes.MapHub<>("/chat");
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
