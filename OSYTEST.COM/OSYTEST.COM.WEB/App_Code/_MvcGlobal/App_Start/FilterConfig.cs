using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TOUR.THETRAVEL.CO.KR.WEB.App_Code._MvcGlobal.App_Start
{
    /// <summary>
    /// FilterConfig의 요약 설명입니다.
    /// </summary>
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}