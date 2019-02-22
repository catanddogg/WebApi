using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using IllyaVirych.Web.Controllers;
using IllyaVirych.Web.DapperRepository;
using IllyaVirych.Web.Interface;
using IllyaVirych.Web.Models;
using IllyaVirych.Web.Repository;
using IllyaVirych.Web.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace IllyaVirych.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<TaskController>();
            //builder.RegisterType<TaskRepository>().As<ITaskRepository>(); //EF
            builder.RegisterType<DapperTaskRepository>().As<ITaskRepository>(); //Dapper
            builder.RegisterType<TaskService>().As<ITaskService>();
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
