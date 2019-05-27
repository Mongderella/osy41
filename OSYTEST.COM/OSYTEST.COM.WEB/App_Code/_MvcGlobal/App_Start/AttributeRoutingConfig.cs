using System.Web.Routing;
using AttributeRouting.Web.Mvc;

[assembly: WebActivator.PreApplicationStartMethod(typeof(TOUR.THETRAVEL.CO.KR.WEB.App_Code._MvcGlobal.App_Start.AttributeRoutingConfig), "Start")]

namespace TOUR.THETRAVEL.CO.KR.WEB.App_Code._MvcGlobal.App_Start
{
    public static class AttributeRoutingConfig
	{
		public static void RegisterRoutes(RouteCollection routes) 
		{    
			// See http://github.com/mccalltd/AttributeRouting/wiki for more options.
			// To debug routes locally using the built in ASP.NET development server, go to /routes.axd
            
			routes.MapAttributeRoutes();
		}

        public static void Start() 
		{
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
