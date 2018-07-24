using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Superheroes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*
            routes.MapRoute(
                "Superhero", "Superhero/{name}", new
                {
                    controller = "Superhero", action = "Search", name =
                    UrlParameter.Optional
                });
            */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Superhero", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
