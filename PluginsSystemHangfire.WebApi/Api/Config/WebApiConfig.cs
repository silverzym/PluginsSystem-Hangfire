using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace PluginsSystemHangfire
{
    //public static class WebApiConfig
    //{
    //    public static void Register(HttpConfiguration config)
    //    {
    //        // Web API routes
    //        config.MapHttpAttributeRoutes();
    //        // 避免跟 AbpWebApiController 定义的路由 冲突
    //        // DefaultApi -> _DefaultApi
    //        config.Routes.MapHttpRoute(
    //            name: "_DefaultApi",
    //            routeTemplate: "api/{controller}/{id}",
    //            defaults: new { id = RouteParameter.Optional }
    //        );

    //        var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
    //        jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    //    }
    //}
}
