using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Academy.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling =
                Newtonsoft.Json.PreserveReferencesHandling.None;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //// Enables query support for actions with IQueryable<T> return type (requires OData package).
            //// To avoid processing unexpected or malicious queries, use the [Queryable] attribute to validate incoming queries.
            //config.EnableQuerySupport();

            // Enables the support for CORS (requires Microsoft.AspNet.WebApi.Cors).
            config.EnableCors(new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*"));
        }
    }
}
