using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ManageEmployees.BusinessLogic;
using ManageEmployees.BusinessLogic.Interfaces;
using ManageEmployees.DataAccess;
using ManageEmployees.DataAccess.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            RegisterSimpleInjection();

            // Web API routes
            config.EnableCors();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void RegisterSimpleInjection()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IEmployeeAccess, EmployeeAccess>(Lifestyle.Scoped);
            container.Register<IEmployeeLogic, EmployeeLogic>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
