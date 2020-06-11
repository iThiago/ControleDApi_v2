
using ControleDApi.DAL;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
//using MySql.Data.Entity;
using System.Data.Entity;
using MySql.Data.EntityFramework;
using System.Net.Http.Formatting;

namespace ControleDApi.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            //ConfigureRotas(config);
            //config.EnableCors();



            app.CreatePerOwinContext(Context.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);


            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/Login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new ControleDAuthorizationServerProvider(),
            };
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            //var corsAttr = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(corsAttr);
            app.UseCors(CorsOptions.AllowAll);
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());


            config.Formatters.JsonFormatter
                        .SerializerSettings
                        .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter
                       .SerializerSettings
                       .NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            ConfigureRotas(config);
            app.UseWebApi(config);

            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            //SwaggerConfig.Register();

            //GlobalConfiguration.Configuration.Formatters.Clear();
            //GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());

            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings
            //        .Add(new RequestHeaderMapping("Accept",
            //                  "text/html",
            //                  StringComparison.InvariantCultureIgnoreCase,
            //                  true,
            //                  "application/json"));

        }
        private static void ConfigureRotas(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}