using System.Web.Mvc;
using System.Web.Routing;

namespace Web.Core
{
    public class RoutesBuilder
    {
        public static void Install(RouteCollection routes)
        {
            routes.MapRoute("Messages", "messages", new { controller = "Messages", action = "Index" });
            routes.MapRoute("MessageEdit", "messages/{id}/edit", new { controller = "Messages", action = "Edit" });    
        }
    }
}