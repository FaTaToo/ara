// --------------------------------------------------------------------------------------------------------------------
/* <header file="RouteConfig.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement RouteConfig.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

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