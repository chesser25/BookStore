using System.Web.Mvc;
using System.Web.Routing;

namespace BookStoreWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "",
                new
                {
                    controller = "Home",
                    action = "Index",
                    category = (string)null,
                    page = 1
                });

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Home", action = "Index", category = (string)null },
                constraints: new {page = @"\d+" });

            routes.MapRoute(null,
                "{category}",
                new { controller = "Home", action = "Index", page = 1 }
            );

            routes.MapRoute(null,
                "{category}/Page{page}",
                new { controller = "Home", action = "Index" },
                new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");

        }
    }
}
