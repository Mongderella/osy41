using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web.Mvc;
using TOUR.THETRAVEL.CO.KR.WEB.App_Code.Common;
using NLog;
using System.Configuration;

namespace TOUR.THETRAVEL.CO.KR.WEB.App_Code._MvcGlobal.Controllers
{
    /// <summary>
    /// Controller 의 Base 가 되는 클래스
    /// </summary>
    public class ControllerCustomBase : Controller
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Detecting Device
            ViewBag._IsMobile = HelperController.IsMobile();


            #region Select View ( PC / Mobile )

            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            ViewBag._ViewName = actionName;

            // Web.config 에 IsMobileViewSupport 설정에 따라 
            string isMobileViewSupport = ConfigurationManager.AppSettings["IsMobileViewSupport"].ToString();

            if (isMobileViewSupport.ToUpper().Equals("Y"))
            {
                // Mobile View 대상이 아닌 Action 검사
                string[] ignoredActions = ConfigurationManager.AppSettings["IgnoredActions"].Split(new string[1] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                bool isIgnoredAction = false;

                foreach (string n in ignoredActions)
                {
                    if (actionName.ToLower().Equals(n.ToLower()))
                    {
                        isIgnoredAction = true;
                        break;
                    }
                }

                // Formal View 의 경우 모바일 / PC 분기 ( Custom Partial View 의 경우 따로 분기 처리 하지 않음 )
                if (!string.IsNullOrEmpty(actionName) && actionName.Substring(0, 1) != "_"  && isIgnoredAction == false)
                {
                    string viewName = HelperController.GetViewName((Controller)this.ControllerContext.Controller, this.ControllerContext.RouteData.Values["action"].ToString());

                    // View 가 존재하지 않아 Response.Redirect 처리 됐을 경우 더 이상 서버 요소 변경하지 않아야 함. ( Warning 유발 방지 )
                    if (viewName.Equals("-1"))
                    {
                        filterContext.Result = new RedirectResult("/package/main");
                        return;
                    }

                    ViewBag._ViewName = viewName;
                }
            }
            else
            {
                // Action 에서의 Data 처리가 Mobile 로 분기되는 것을 막기 위해 False 처리
                ViewBag._IsMobile = false;
            }

            #endregion / Select View ( PC / Mobile )
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            //Exception e = filterContext.Exception;
            ////Log Exception e
            //filterContext.ExceptionHandled = true;
            //filterContext.Result = new ViewResult()
            //{
            //    ViewName = "Error"
            //};

            base.OnException(filterContext);

            Exception ex = filterContext.Exception;

            //HelperNLog.WriteNLog(Request.Url.OriginalString,
            //    this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), ex.ToString());

            string rootPath = Server.MapPath("~");
            NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(rootPath + "\\NLog.config", true);


            #region Get Referrer URL 

            string referrerUrl = string.Empty;

            // ReferrerUrl 이 있을 경우 조회
            if (this.ControllerContext.RequestContext.HttpContext.Request.UrlReferrer != null)
            {
                try
                {
                    referrerUrl = this.ControllerContext.RequestContext.HttpContext.Request.UrlReferrer.AbsoluteUri;
                }
                catch
                {
                    referrerUrl = "Failed Get Referrer URL";
                }
            }

            #endregion / Get Referrer URL


            logger.Error(string.Format(@"
                < Controller Error >
                [URL]           : {0}
                [REF URL ]      : {4}
                [Controller]    : {1}
                [Action]        : {2} 
                [ErrMsg]        : {3}"
            , Request.Url.OriginalString,
                this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), ex.ToString(), referrerUrl));
        }
    }
}