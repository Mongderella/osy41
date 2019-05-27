using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOUR.THETRAVEL.CO.KR.WEB.App_Code.Common
{
    /// <summary>
    /// MetaTags의 요약 설명입니다.
    /// </summary>
    public class HelperNLog
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
        public static Logger logger4Views = LogManager.GetLogger("TOUR.THETRAVEL.CO.KR.WEB.VIEWS");
        public static Logger logger4Common = LogManager.GetLogger("TOUR.THETRAVEL.CO.KR.WEB.App_Code.Common.*");
        public static Logger logger4Secure = LogManager.GetLogger("TOUR.THETRAVEL.CO.KR.WEB.Secure");

        public static string rootPath = System.Web.HttpContext.Current.Server.MapPath("~");

        /// <summary>
        /// NLog 기록 ( Secure 함수 전용 )
        /// </summary>
        /// <param name="description">로그 종류</param>
        /// <param name="url">Request Url</param>
        /// <param name="referrerUrl">Referrer Url</param>
        /// <param name="ipAddr">Client IP Address</param>
        static public void WriteNLog4Secure(string description, string url, string referrerUrl, string ipAddr)
        {

            NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(rootPath + "\\NLog.config", true);

            logger4Secure.Error(string.Format(@"
                < Secure Error >   
                [DESC]          : {0}
                [URL]           : {1}
                [REFERRER URL]  : {2}
                [IP]            : {3}"
            , description, url, referrerUrl, ipAddr));
        }

        /// <summary>
        /// NLog 기록 ( App_Code.Common 전용 )
        /// </summary>
        /// <param name="url"></param>
        /// <param name="errMsg"></param>
        static public void WriteNLog4Common(string url, string errMsg)
        {
            NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(rootPath + "\\NLog.config", true);

            logger4Common.Error(string.Format(@"
                < Common Error >   
                [URL]           : {0}
                [ErrMsg]        : {1}"
            , url, errMsg));
        }

        /// <summary>
        /// NLog 기록 ( MVC View 전용 )
        /// </summary>
        /// <param name="url"></param>
        /// <param name="errMsg"></param>
        static public void WriteNLog4Views(string url, string errMsg)
        {
            NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(rootPath + "\\NLog.config", true);

            logger4Views.Error(string.Format(@"
                < View Error >   
                [URL]           : {0}
                [ErrMsg]        : {1}"
            , url, errMsg));
        }

        /// <summary>
        /// NLog 기록
        /// </summary>
        static public void WriteNLog(string url, string controllerName, string actionName, string errMsg)
        {
            NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(rootPath + "\\NLog.config", true);

            logger.Error(string.Format(@"
                < Controller Error > 
                [URL]           : {0}
                [Controller]    : {1}
                [Action]        : {2} 
                [ErrMsg]        : {3}"
            , url, controllerName, actionName, errMsg));
        }

        /// <summary>
        /// NLog 기록 ( ApiController )
        /// </summary>
        static public void WriteNLog4ApiController(string url, string errMsg)
        {
            NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(rootPath + "\\NLog.config", true);

            logger.Error(string.Format(@"
                < API Controller Error > 
                [URL]           : {0}
                [ErrMsg]        : {1}"
            , url, errMsg));
        }
    }
}