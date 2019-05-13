using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using FinanceWebsite.DataService.App_Start;

namespace FinanceWebsite.DataService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            StructuremapWebApi.Start();

            // Web API configuration and services
            config.EnableCors();

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
