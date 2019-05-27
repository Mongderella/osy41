using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace TOUR.THETRAVEL.CO.KR.WEB.App_Code.Common
{
    /// <summary>
    /// Controller 의 동작을 지원하는 클래스
    /// </summary>
    public class HelperController
    {
        private const string POSTFIX = "_Mobile";

        /// <summary>
        /// Controller 와 Action Name 을 인자로 받아 View 가 유효한지 여부를 반환합니다.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ViewExists(Controller controller, string name)
        {
            ViewEngineResult result = ViewEngines.Engines.FindView(controller.ControllerContext, name, null);
            return (result.View != null);
        }

        /// <summary>
        /// 모바일 기기 여부 판별하고, 그 결과를 리턴합니다.
        /// </summary>
        /// <returns></returns>
        public static bool IsMobile()
        {
            Regex reg = new Regex("iPhone|iPod|iPad|Mobile|UP.Browser|Android|BlackBerry|Windows CE|Nokia|webOS|Opera Mini|SonyEricsson|Opera Mobi|Windows Phone|IEMobile|POLARIS|SKT|LG|LGPlayer|Bada|Kindle|Wii", RegexOptions.IgnoreCase);

            try
            {
                return !String.IsNullOrEmpty(HttpContext.Current.Request.UserAgent) && reg.IsMatch(HttpContext.Current.Request.UserAgent) ? true : false;
            }
            catch(Exception ex)
            {
                HelperNLog.WriteNLog4Common(HttpContext.Current.Request.Url.AbsoluteUri, ex.ToString());

                return false;
            }
        }

        /// <summary>
        /// 모바일 기기 여부 판별하고, End Point 에 적합한 View Name 을 리턴합니다.
        /// </summary>
        /// <returns></returns>
        public static string GetViewName(string actionName)
        {
            string viewName = string.Empty;

            try
            {
                string userAgent = HttpContext.Current.Request.UserAgent.ToLower();
                
                if (IsMobile())
                {
                    // 모바일 기기일 경우 Prefix "m_" 을 Action Name 에 붙임
                    viewName = actionName + POSTFIX;
                }
                else
                {
                    viewName = actionName;
                }
            }
            catch(Exception ex)
            {
                HelperNLog.WriteNLog4Common(HttpContext.Current.Request.Url.AbsoluteUri, ex.ToString());
            }

            return viewName;
        }

        /// <summary>
        /// PC / Mobile 용 View Name 을 구하고 그 값을 반환합니다. View 가 유효하지 않을 경우 Redirect 처리 됩니다.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="actionName"></param>
        /// <returns></returns>
        public static string GetViewName(Controller controller, string actionName)
        {
            string viewName = string.Empty;

            try
            {
                // Custom PartialView 와 같이 {ViewName}_Mobile 로 작성된 Action 의 경우, Multi View 검증을 하지 않는다.
                if (actionName.ToLower().IndexOf("_mobile") == -1)
                {
                    string userAgent = HttpContext.Current.Request.UserAgent.ToLower();

                    if (IsMobile())
                    {
                        // 모바일 기기일 경우 Postfix "_Mobile" 을 Action Name 에 붙임
                        viewName = actionName + POSTFIX;
                    }
                    else
                    {
                        viewName = actionName;
                    }

                    // View 가 존재하는지 여부 체크 후, Redirect 처리 ( Get Verb 만 대상 )
                    if (HttpContext.Current.Request.HttpMethod == "GET")
                    {
                        if (ViewExists(controller, viewName) == false)
                            return "-1";
                    }
                }
            }
            catch (Exception ex)
            {
                HelperNLog.WriteNLog4Common(HttpContext.Current.Request.Url.AbsoluteUri, ex.ToString());
            }

            return viewName;
        }
    }
}