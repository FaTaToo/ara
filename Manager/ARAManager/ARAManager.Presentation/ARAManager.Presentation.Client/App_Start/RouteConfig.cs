using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace ARAManager.Presentation.Client
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.EnableFriendlyUrls();
        }
    }
}