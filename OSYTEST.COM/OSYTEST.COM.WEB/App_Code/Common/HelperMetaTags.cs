using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOUR.THETRAVEL.CO.KR.WEB.App_Code.Common
{
    /// <summary>
    /// MetaTags의 요약 설명입니다.
    /// </summary>
    public class HelperMetaTags
    {
        //public MetaTags()
        //{
        //    //
        //    // TODO: 여기에 생성자 논리를 추가합니다.
        //    //
        //}

        /// <summary>
        /// Meta Keyword 구문 생성
        /// </summary>
        static public string SetMetaKeyword(string keyword)
        {
            string returnValue = "<meta name=\"keywords\" content=\"{0}\">";

            returnValue = string.Format(returnValue, keyword);

            return returnValue;
        }

        /// <summary>
        /// Meta Description 구문 생성
        /// </summary>
        static public string SetMetaDescription(string keyword)
        {
            string returnValue = "<meta property=\"description\" content=\"{0}\">";

            returnValue = string.Format(returnValue, keyword);

            return returnValue;
        }

        /// <summary>
        /// Meta Image 구문 생성
        /// </summary>
        static public string SetMetaImages(string keyword)
        {
            string returnValue = "<meta property=\"og:image\" content=\"{0}\">";

            returnValue = string.Format(returnValue, keyword);

            return returnValue;
        }

        /// <summary>
        /// 검색로봇 메타태그 설정
        /// </summary>
        static public string SetRobotMetaTag(HttpRequestBase request)
        {
            string robotsTag = "<meta name=\"robots\" content=\"index, follow\">";
            //string currentPath = Request.Path;
            string currentPath = request.Path;
            string[,] excludePath = new string[,] { {"/Common/", "D"},
                                                {"/customer/fitconsult", "D"},
                                                {"/customer/consult", "D"},
                                                {"/customer/valuation", "D"},
                                                {"/discovery/Together", "D"},
                                                {"/Exporter/", "D"},
                                                {"/gate/", "D"},
                                                {"/global/", "D"},
                                                {"/golf/", "D"},
                                                {"/goods/ajax/", "D"},
                                                {"/home/", "D"},
                                                {"/housing/category/Hotel_Main.aspx", "A"},
                                                {"/housing/category/Condo_Main.aspx", "A"},
                                                {"/housing/category/Pension_Main.aspx", "A"},
                                                {"/housing/Search/AreaList.aspx", "A"},
                                                {"/housing/Search/ThemeListHotel.aspx", "A"},
                                                {"/housing/Search/WeekendList.aspx", "A"},
                                                {"/housing/Search/SpecialList.aspx", "A"},
                                                {"/housing/Search/Weekend_List.aspx", "A"},
                                                {"/housing/Search/Special_List.aspx", "A"},
                                                {"/housing/Search/Theme_List.aspx", "A"},
                                                {"/housing/Information/Condo_Chain_Master.aspx", "A"},
                                                {"/housing/Goods/Goods_DetailInfo.aspx", "A"},
                                                {"/housing/", "D"},
                                                {"/hSale/", "D"},
                                                {"/html/", "D"},
                                                {"/IISError/", "D"},
                                                {"/image/", "D"},
                                                {"/ipoint/", "D"},
                                                {"/m/", "D"},
                                                {"/member/", "D"},
                                                {"/mypage/", "D"},
                                                {"/partner/", "D"},
                                                {"/planner/", "D"},
                                                {"/reservation/", "D"} };

            for (int i = 0; i < excludePath.GetLength(0); i++)
            {
                string path = excludePath[i, 0];
                string type = excludePath[i, 1];

                if (currentPath.IndexOf(path, StringComparison.CurrentCultureIgnoreCase) == -1) continue;

                if (type == "A") break;
                if (type == "D")
                {
                    robotsTag = "<meta name=\"robots\" content=\"noindex, nofollow\">";
                    break;
                }
            }

            return robotsTag;
        }

        /// <summary>
        /// IE10 모드 나머지 구분 메타테그 삽입
        /// </summary>
        static public string SetIEMetaTag(HttpRequestBase request)
        {
            string returnValue = string.Empty;

            if (((request.Browser.Browser == "IE") || (request.Browser.Browser == "InternetExplorer"))
            && (((request.Browser.MajorVersion >= 10) && (request.Browser.MajorVersion < 11))
            || ((request.Browser.MajorVersion >= 7) && (request.Browser.MajorVersion < 8))))
            {
                //show IE10 content
                //returnValue = "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\"/>";
                returnValue = "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" />";

            }
            else
            {
                //show else content 
                //returnValue = "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" />";
                returnValue = "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" />";
            }

            return returnValue;
        }
    }
}