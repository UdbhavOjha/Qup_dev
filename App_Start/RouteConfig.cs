using System;
using System.Web;
using System.Web.UI;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Qup
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //var settings = new FriendlyUrlSettings();
            //settings.AutoRedirectMode = RedirectMode.Permanent;
            //routes.EnableFriendlyUrls(settings);
            //routes.EnableFriendlyUrls();

            // https://forums.asp.net/t/2054029.aspx?Disable+Mobile+View+Switcher

            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings, new MyWebFormsFriendlyUrlResolver());
        }
    }

    public class MyWebFormsFriendlyUrlResolver : Microsoft.AspNet.FriendlyUrls.Resolvers.WebFormsFriendlyUrlResolver
    {
        protected override bool TrySetMobileMasterPage(HttpContextBase httpContext, Page page, String mobileSuffix)
        {
            if (mobileSuffix == "Mobile")
            {
                return false;
            }
            else
            {
                return base.TrySetMobileMasterPage(httpContext, page, mobileSuffix);
            }
        }
    }
}
