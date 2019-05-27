using System.Web;
using System.Web.Optimization;

namespace TOUR.THETRAVEL.CO.KR.WEB.App_Code._MvcGlobal.App_Start
{
    public class BundleConfig
    {
        // 번들 작성에 대한 자세한 내용은 http://go.microsoft.com/fwlink/?LinkId=301862를 참조하십시오.
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Sample Codes 

            //// Modernizr의 개발 버전을 사용하여 개발하고 배우십시오. 그런 다음
            //// 프로덕션할 준비가 되면 http://modernizr.com의 빌드 도구를 사용하여 필요한 테스트만 선택하십시오.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            #endregion / Sample Codes


            #region SCRIPT

            // Default Jquery Set
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Encrypt Js
            bundles.Add(new ScriptBundle("~/bundles/encrypt").Include(
                        "~/Scripts/Encrypt/System.debug.js"
                        , "~/Scripts/Encrypt/System.IO.debug.js"
                        , "~/Scripts/Encrypt/System.Text.debug.js"
                        , "~/Scripts/Encrypt/System.Convert.debug.js"
                        , "~/Scripts/Encrypt/System.BitConverter.debug.js"
                        , "~/Scripts/Encrypt/System.BigInt.debug.js"
                        , "~/Scripts/Encrypt/System.Security.Cryptography.SHA1.debug.js"
                        , "~/Scripts/Encrypt/System.Security.Cryptography.debug.js"
                        , "~/Scripts/Encrypt/System.Security.Cryptography.RSA.debug.js"
                        , "~/Scripts/Views/Common/Encrypt.js"
                        ));

            #endregion / SCRIPT


            #region CSS

            //// Common CSS For Free Renewal 
            //bundles.Add(new StyleBundle("~/bundles/css_free_renewal").Include(
            //          "~/global/css/layout.css"
            //          , "~/global/css/ui_common.css"
            //          , "~/global/css/ui_module.css"
            //          , "~/global/css/freeN.css"
            //          ));

            #endregion / CSS

            // getLoginYN() 등 gate.js 관련 스크립트 오류 발생으로 Bundling / Minification 기능 끔 ( 2017-04-27 )
            // 여행 모바일 개편 작업에서 Bundling / Minification 기능 켬 ( 2017-07-02 )
            BundleTable.EnableOptimizations = true;

        }
    }
}
