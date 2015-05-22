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

           // routes.MapRoute(
           //    name: "IndexProject",
           //    url: "Project/Index/{id}",
           //    defaults: new { controller = "Project", action = "Index", id = UrlParameter.Optional }
           //);

           // routes.MapRoute(
           //    name: "AddProject",
           //    url: "Project/Add/{id}",
           //    defaults: new { controller = "Project", action = "Create", id = UrlParameter.Optional }
           //);

           // routes.MapRoute(
           //    name: "ActivityTypeIndex",
           //    url: "ActivityType/Index/{id}",
           //    defaults: new { controller = "ActivityType", action = "Index", id = UrlParameter.Optional }
           //);

           // routes.MapRoute(
           //    name: "AddActivityType",
           //    url: "ActivityType/Add/{id}",
           //    defaults: new { controller = "ActivityType", action = "Create", id = UrlParameter.Optional }
           //);

           // routes.MapRoute(
           //    name: "ActivityIndex",
           //    url: "Activity/Index/{id}",
           //    defaults: new { controller = "Activity", action = "Index", id = UrlParameter.Optional }
           //);

           // routes.MapRoute(
           //    name: "AddActivity",
           //    url: "Activity/Add/{id}",
           //    defaults: new { controller = "Activity", action = "Create", id = UrlParameter.Optional }
           //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
