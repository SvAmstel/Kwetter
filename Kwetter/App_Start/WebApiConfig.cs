using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Kwetter
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(name: "API Default", routeTemplate: "api/{controller}");
        }
    }
}
