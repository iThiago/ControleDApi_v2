using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using ControleDApi;
using ControleDApi.App_Start;

namespace ControleDApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)

        {
            // Web API configuration and services
            //var corsAttr = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(corsAttr);
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

          

            //config.Formatters.Clear();
            //config.Formatters.Add(new JsonMediaTypeFormatter());


            config.Formatters.JsonFormatter
                        .SerializerSettings
                        .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            SwaggerConfig.Register();




            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            //config.Formatters.JsonFormatter.SupportedMediaTypes
            // .Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
