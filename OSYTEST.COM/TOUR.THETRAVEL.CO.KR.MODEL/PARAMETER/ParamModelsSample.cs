namespace TOUR.THETRAVEL.CO.KR.MODEL.PARAMETER.ParamModelsSample
{
    /* For Any Controller ( Controller / View 에 종속적이지 않은 공통 Model ) */

    #region Parameter Models

    /// <summary>
    /// TOUR.THETRAVEL.CO.KR/api/eventbannerlist
    /// </summary>
    public class PramModelD1
    {
        // Page Group Code
        public int PageGroupCD { get; set; }

        // Category Code
        public int CategoryCD { get; set; }

        // Goods Group : 모바일 특가 상품 Seq
        public int MobileSpecialPriceGoodsGroupSeq { get; set; }

        // Keyword Link : 상단 배너 Seq
        public int KeywordLinkTagGroupSeqTop { get; set; }

        // Keyword Link : 중단 배너 Seq 
        public int KeywordLinkTagGroupSeqMiddle { get; set; }

        // Keyword Link : 하단 배너 Seq
        public int KeywordLinkTagGroupSeqBottom { get; set; }

        // Goods Group Array : Tab 상품 노출 부분 Seq 배열 
        public int[] GoodsGroupSeqsForTagSection { get; set; }
    }

    ///// <summary>
    ///// TOUR.THETRAVEL.CO.KR/common/list
    ///// parameter model - 상품검색 페이지 > 기초상품 검색파라미터
    ///// </summary>
    //public class PramModelList
    //{
    //    //public int PageGroupCD { get; set; }
    //    //public int CategoryCD { get; set; }
    //    //public int BestSellerGoodsGroupSeq { get; set; }
    //    //public int ListBannerGroupSeq { get; set; }
    //}

    /// <summary>
    /// TOUR.THETRAVEL.CO.KR/common/list 
    /// parameter model - 상품검색 페이지 > 기초상품 검색파라미터
    /// </summary>
    public class PramModelSearchBaseGoodsList
    {
        public int CategoryCD { get; set; }
        public string SearchKeyword { get; set; }
        public string DepartureDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int DayCntFrom { get; set; }
        public int DayCntTo { get; set; }
        public int AdultRateFrom { get; set; }
        public int AdultRateTo { get; set; }
        public string OrderType { get; set; }
        public int PageSize { get; set; }
        public int PageNum { get; set; }
        public string FromMobileYN { get; set; }        
    }

    #endregion / Parameter Models
}
