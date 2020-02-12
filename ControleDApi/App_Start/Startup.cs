﻿
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
using System.Web.Http.Cors;

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

            ConfigureRotas(config);
            app.UseWebApi(config);

            //SwaggerConfig.Register();

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