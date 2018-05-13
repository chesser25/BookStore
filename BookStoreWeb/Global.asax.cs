using BookStoreDomainModel.Entities;
using BookStoreWeb.Helpers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStoreWeb
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Add custom binder
            ModelBinders.Binders.Add(typeof(Cart), new CartBinder());
        }
    }
}
