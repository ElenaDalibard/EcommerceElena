using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EcommerceElena
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Produit",
                url: "TireLire/{id}",
                defaults: new { controller = "Produit", action = "Details" },
                constraints: new { id = "[0-9]+" }
                );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Produit", action = "Gallery", id = UrlParameter.Optional }
            );

        }
    }
}
