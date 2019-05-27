using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TOUR.THETRAVEL.CO.KR.WEB.App_Code.Common;
using TOUR.THETRAVEL.CO.KR.WEB.App_Code._MvcGlobal.App_Start;

namespace TOUR.THETRAVEL.CO.KR.WEB
{
    /// <summary>
    /// Global의 요약 설명입니다.
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            #region XSS, SQL Injection 방지

            string originalPath = HttpContext.Current.Request.Path;
            string queryString = string.Empty;

            if (HttpContext.Current.Request.QueryString.Count > 0)
            {
                queryString = HttpContext.Current.Request.QueryString.ToString();

                // Injection 문자 존재 여부
                bool hasInjectionCharacters;

                // Query String 에서 XSS, SQL Injection 공격에 사용되는 Single quotation, Dobule quotation, Semi colon 제거 / Less Than, Greater Than  치환
                queryString = HelperSecurity.WithoutInjectionCharacters(queryString, out hasInjectionCharacters);

                // Injection 문자가 존재할 경우, 메인 페이지로 Redirect
                if (hasInjectionCharacters)
                {
                    Context.RewritePath("/");
                }
                else
                {
                    Context.RewritePath(originalPath + "?" + queryString);
                }
            }

            #endregion / XSS, SQL Injection 방지
        }

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (custom == "device")
            {
                string deviceType = string.Empty;

                if (HelperController.IsMobile())
                    deviceType = "Mobile";
                else
                    deviceType = "PC";

                //return context.Request.Browser.Browser +
                //       context.Request.Browser.MajorVersion;

                return deviceType;
            }
            else
            {
                return base.GetVaryByCustomString(context, custom);
            }
        }

        protected void Application_PreSendRequestHeaders()
        {
            // Response Header 에 노출되는 서버와 사이트 정보를 제거
            Response.Headers.Remove("Server");
            Response.Headers.Remove("X-AspNet-Version");
            Response.Headers.Remove("X-AspNetMvc-Version");
        }
    }
}