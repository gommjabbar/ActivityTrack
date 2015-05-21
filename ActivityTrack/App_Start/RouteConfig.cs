using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ActivityTrack
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Index",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Activity", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Add",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Activity", action = "Create", id = UrlParameter.Optional }
           );
        }
    }
}
