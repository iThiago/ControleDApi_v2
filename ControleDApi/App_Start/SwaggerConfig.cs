using System.Web.Http;
using WebActivatorEx;
using ControleDApi;
using Swashbuckle.Application;
using ControleDApi.App_Start;
using System.Net.Http.Formatting;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ControleDApi.App_Start
{
    public class SwaggerConfig
    {
        public static void Register()
        {


            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Controle D");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                })
                .EnableSwaggerUi(c =>
                {
                });
            //GlobalConfiguration.Configuration.Formatters.Clear();
            //GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
        }
        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\ControleDApi.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
