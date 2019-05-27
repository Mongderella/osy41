using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TOUR.THETRAVEL.CO.KR.WEB.App_Code._MvcGlobal.App_Start
{
    /// <summary>
    /// RouteConfig의 요약 설명입니다.
    /// </summary>
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();


            #region ROUTE

            //// For Legacy Default Page
            //routes.MapPageRoute("Root",
            //    "", 
            //    "~/default.aspx", false, null, new RouteValueDictionary(new { controller = new IncomingRequestConstraint() }));

            ////
            //routes.MapRoute(
            //    name: "API",
            //    url: "api/{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            // ROUTE : Sample
            routes.MapRoute(
                name: "Common",
                url: "Common",
                defaults: new { controller = "Common", action = "Main" }
            );

            // For MVC Pattern Url 
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Common", action = "Main" }
            );

            #endregion / ROUTE
        }

        public class IncomingRequestConstraint : IRouteConstraint
        {
            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                return routeDirection == RouteDirection.IncomingRequest;
            }
        }

    }
}