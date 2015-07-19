using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shorty.Web
{
    public class ShortyRoute : Route
    {
        public ShortyRoute(string url, IRouteHandler routeHandler) : base(url, routeHandler)
        {
        }

        public ShortyRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler) : base(url, defaults, routeHandler)
        {
        }

        public ShortyRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler) : base(url, defaults, constraints, routeHandler)
        {
        }

        public ShortyRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler) : base(url, defaults, constraints, dataTokens, routeHandler)
        {

            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException("Route url must be defined", "url");

            var thisUrl = url; 


        }


       


    }




    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute("CatchAll", "{*shortUrl}", new { controller = "Home", action = "Resolve", shortUrl = UrlParameter.Optional });
            //routes.MapRoute("resolver", "{shortUrl}", new { controller = "Home", action = "Resolve", shortUrl = ""});

            routes.MapRoute("resolver", "1{id}", new { controller = "Home", action = "Resolve" }); 

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

          
        }
    }
}
