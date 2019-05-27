using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Mvc;

namespace TOUR.THETRAVEL.CO.KR.WEB.App_Code._MvcGlobal.App_Start
{
    /// <summary>
    /// WebApiConfig의 요약 설명입니다.
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 경로
            config.MapHttpAttributeRoutes();

            // 상품 리스트 조회
            config.Routes.MapHttpRoute(
             name: "Api_DepartureDateGoods",
             routeTemplate: "api/DepartureDateGoods/{baseGoodsCD}/{startDT}/{endDT}/{airLineCD}/{sort}/{currentPage}/{pageSize}/{sortMode}",
             defaults: new
             {
                 controller = "DepartureDateGoods",
                 baseGoodsCD = "{baseGoodsCD}",
                 startDT = "{startDT}",
                 endDT = "{endDT}",
                 airLineCD = "{airLineCD}",
                 sort = "{sort}",
                 currentPage = "{currentPage}",
                 pageSize = "{pageSize}",
                 sortMode = "{sortMode}"
             }
            );

            // 상품 리스트 조회
            config.Routes.MapHttpRoute(
             name: "Api_GoodsList",
             routeTemplate: "api/GoodsList/{cateCD}/{baseGoodsNM}/{departureDT}/{startDT}/{endDT}/{dayCntFrom}/{dayCntTo}/{adultRateFrom}/{adultRateTo}/{sort}/{pageSize}/{pageNum}/{fromMobileYN}",
             //routeTemplate: "api/GoodsList",
             defaults: new
             {
                 controller = "GoodsList",
                 cateCD = "{cateCD}",
                 baseGoodsNM = "{baseGoodsNM}",
                 departureDT = "{departureDT}",
                 startDT = "{startDT}",
                 endDT = "{endDT}",
                 dayCntFrom = "{dayCntFrom}",
                 dayCntTo = "{dayCntTo}",
                 adultRateFrom = "{adultRateFrom}",
                 adultRateTo = "{adultRateTo}",
                 sort = "{sort}",
                 pageSize = "{pageSize}",
                 pageNum = "{pageNum}",
                 fromMobileYN = "{fromMobileYN}"
             }
            //defaults: new { controller = "GoodsList" }
            );

            // 먹고찍고 상품 리스트 조회
            config.Routes.MapHttpRoute(
             name: "Api_ThemeGoodsList",
             routeTemplate: "api/ThemeTourGoodsList/{cateCD}/{baseGoodsNM}/{departureDT}/{dayCntFrom}/{dayCntTo}/{adultRateFrom}/{adultRateTo}/{sort}/{pageSize}/{pageNum}",
             defaults: new
             {
                 controller = "ThemeTourGoodsList",
                 cateCD = "{cateCD}",
                 baseGoodsNM = "{baseGoodsNM}",
                 departureDT = "{departureDT}",
                 dayCntFrom = "{dayCntFrom}",
                 dayCntTo = "{dayCntTo}",
                 adultRateFrom = "{adultRateFrom}",
                 adultRateTo = "{adultRateTo}",
                 sort = "{sort}",
                 pageSize = "{pageSize}",
                 pageNum = "{pageNum}"
             }
                //defaults: new { controller = "GoodsList" }
            );
            
            // 내륙테마 금일출발 상품 리스트 조회
            config.Routes.MapHttpRoute(
             name: "Api_DomesticThisWeekGoodsList",
             routeTemplate: "api/DomesticThisWeekGoodsList/{cateCD}/{baseGoodsNM}/{trafficCD}/{dayCntFrom}/{dayCntTo}/{adultRateFrom}/{adultRateTo}/{pageSize}/{pageNum}",
             defaults: new
             {
                 controller = "DomesticThisWeekGoodsList",
                 cateCD = "{cateCD}",
                 baseGoodsNM = "{baseGoodsNM}",
                 trafficCD = "{trafficCD}",
                 dayCntFrom = "{dayCntFrom}",
                 dayCntTo = "{dayCntTo}",
                 adultRateFrom = "{adultRateFrom}",
                 adultRateTo = "{adultRateTo}",
                 pageSize = "{pageSize}",
                 pageNum = "{pageNum}"
             }
                //defaults: new { controller = "GoodsList" }
            );

            // 이벤트 배너 리스트 조회
            config.Routes.MapHttpRoute(
             name: "Api_EventBannerList",
             //routeTemplate: "api/EventBannerList/{pageGroupCD}/{pcExposeYN}/{mobileExposeYN}/{cateCD}",
             routeTemplate: "api/EventBannerList",
             //defaults: new { controller = "EventBannerList", pageGroupCD = "{pageGroupCD}", exhibitYN = 'Y', pcExposeYN = ' ', mobileExposeYN = ' ', cateCD = UrlParameter.Optional }
             defaults: new { controller = "EventBannerList" }
            );

            // 상품 그룹 조회
            config.Routes.MapHttpRoute(
             name: "Api_GoodsGroup",
             routeTemplate: "api/GoodsGroup/{pageGroupCD}/{cateCD}/{seq}",
             defaults: new { controller = "GoodsGroup", pageGroupCD = "{pageGroupCD}", seq = "{seq}" }
            );

            // 상품 그룹 조회
            config.Routes.MapHttpRoute(
             name: "Api_SMSConcierge",
             routeTemplate: "api/ConciergeSMS/",
             defaults: new { controller = "ConciergeSMS" }
            );

            // 톡집사 추천특가 상품 리스트 조회
            config.Routes.MapHttpRoute(
             name: "Api_ConciergeRecommendGoods",
             routeTemplate: "api/ConciergeRecommendGoods/{apitype}/{pagenum}/{pagesize}/{mobileyn}/{callback}",
             defaults: new
             {
                 controller = "ConciergeRecommendGoods",
                 apitype = "{apitype}",
                 pagenum = "{startDT}",
                 pagesize = "{pagesize}",
                 mobileyn = "{mobileyn}",
                 callback = "{callback}"
             }
            );

            config.Routes.MapHttpRoute(
                name: "Api_PollAnswer",
                routeTemplate: "api/pollanswer/{pollSeq}/{answer}",
                defaults: new { controller = "pollanswer" }
            );

            config.Routes.MapHttpRoute(
                name: "Api_Default",
                routeTemplate: "api/{controller}",
                defaults: new {  }
            );

            //////// Api Controller Log
            //////config.Filters.Add(new ExceptionHandlingAttribute());

            // Api Controller Log & Response Message
            config.Services.Replace(typeof(IExceptionHandler), new ApiGlobalExceptionHandler());

            // Api Action Filter ( Check Referrer )
            config.Filters.Add(new ApiActionFilterAttribute());
        }
    }
}