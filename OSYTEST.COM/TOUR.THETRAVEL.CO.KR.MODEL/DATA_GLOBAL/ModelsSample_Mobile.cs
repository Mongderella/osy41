using TOUR.THETRAVEL.CO.KR.MODEL.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOUR.THETRAVEL.CO.KR.MODEL.DATA_GLOBAL.ModelsSample_Mobile
{
    /* For Any Data */

    #region Data Models

    /// <summary>
    /// 전시 카테고리와 관련된 여러 정보들
    /// </summary>
    public class ModelExhibitInformation
    {
        public string TemplateURL { get; set; }

        public int CateCD { get; set; }

        public string CateNM { get; set; }

        public int Lvl { get; set; }

        public int ParentCateCD { get; set; }

        public string TitleImageBig { get; set; }

        public string TitleImageSmall { get; set; }

        public int TemplateTypeCD { get; set; }

        public string GoodsViewType { get; set; }
    }

    /// <summary>
    /// HTML
    /// </summary>
    public class ModelHtml
    {
        public string PageGroupCD { get; set; }
        public string CateCD { get; set; }
        public string Contents { get; set; }
        public string GoodsExibitYN { get; set; }
        public string TitleExibitYN { get; set; }
        public string RegUserID { get; set; }
        public string RegDT { get; set; }
        public string ContentsUseYN { get; set; }
        public string GoodsExibitYN_Sub { get; set; }
        public string Contents_Sub { get; set; }
        public string TitleExibitYN_Sub { get; set; }
        public string ContentsUseYN_Sub { get; set; }
    }

    /// <summary>
    /// KeywordLink
    /// </summary>
    public class ModelKeywordLink
    {
        public int Seq { get; set; }
        public int PageGroupCD { get; set; }
        public int TagGroupSeq { get; set; }
        public int CateCD { get; set; }
        public string Keyword { get; set; }
        public string KeywordA { get; set; }
        public string KeywordB { get; set; }
        public string LinkURL { get; set; }
        public string ImageURL { get; set; }
        public string IsNewWindow { get; set; }
        public string TagDesc { get; set; }
        public string SortNo { get; set; }
    }

    /// <summary>
    /// 이벤트 배너 ( Touradmin, Tour 사이트에서 사용됨 )
    /// </summary>
    public class ModelEventBanner
    {
        // 이벤트 Identifier
        public int MainSeq { get; set; }

        // 이벤트 고유 번호
        public int PromotionSeq { get; set; }

        // PageGroupCD ( aka. TemplateCD )
        public int PageGroupCD { get; set; }

        // 이벤트 배너 정렬 순서
        public int SortSeq { get; set; }

        // 등록자 ID
        public string RegUserID { get; set; }

        //
        public string ListImage { get; set; }

        // 이벤트명
        public string PromotionTitle { get; set; }

        // PC 노출 여부
        public string PCExposeYN { get; set; }

        // 모바일 노출 여부
        public string MobileExposeYN { get; set; }

        // 
        public string MobileImage { get; set; }

        // 카테고리 코드
        public int CateCD { get; set; }

        //
        public string AreaCateCD { get; set; }

        //
        public string ThemeCateCD { get; set; }

        //
        public string Title { get; set; }

        //
        public string ExibitYN { get; set; }

        //
        public string StartDT { get; set; }

        //
        public string EndDT { get; set; }

        //
        public string TopHtmlYN { get; set; }

        //
        public string RedirectionURL { get; set; }

        //
        public string TopHtml { get; set; }

    }

    /// <summary>
    /// 상품 그룹 
    /// </summary>
    public class ModelGoodsGroup
    {
        // PageGroupCD ( aka. TemplateCD )
        public int PageGroupCD { get; set; }

        // 
        public int PageCateCD { get; set; }

        // Keywordlink Seq
        public int Seq { get; set; }

        // 추가 정보 1
        public string AddValue1 { get; set; }

        // 추가 정보 2
        public string AddValue2 { get; set; }

        //
        public string ModifierCD { get; set; }

        // 상품명
        public string DispGoodsNM { get; set; }

        // 상품 타입 
        public string GoodsType { get; set; }

        // 기초 상품 여부
        public string BaseGoodsYN { get; set; }

        // 카테고리 코드
        public int CateCD { get; set; }

        // 기초 상품 코드
        public string BaseGoodsCD { get; set; }

        // 기초 상품명
        public string BaseGoodsNM { get; set; }

        //
        public string BundleGoodsYN { get; set; }

        // 
        public string StartDT { get; set; }

        //
        public string StartDT2 { get; set; }

        //
        public string EndDT { get; set; }

        // 숙박 일 수
        public int NightCnt { get; set; }

        // 여정 일 수
        public int DayCnt { get; set; }

        //
        public string GoodsClsCD { get; set; }

        //
        public string GoodsClsNM { get; set; }

        // 상품 이미지 파일명
        public string ImageFileNM { get; set; }

        // 최저 상품 가격 ( 출발 상품 중 )
        public string MinAdultRate { get; set; }

        // 최고 상품 가격 ( 출발 상품 중 )
        public string MaxAdultRate { get; set; }

        // 공급사 코드 ( 여행사 - 인터파크 투어 포함 )
        public string SupplierCD { get; set; }

        //
        public string SupplierBaseGoodsCD { get; set; }

        //
        public string EvalPointAvg { get; set; }

        //
        public string EvalNoOfPeople { get; set; }

        //
        public string ReserveRate { get; set; }

        // 상품 설명
        public string GoodsDesc { get; set; }

        // 상품 이미지 파일 명 - ( Json 제외 )
        public string FILENM { get; set; }

        // 출발 상품 코드
        public string GoodsCD { get; set; }

        // 항공사 코드
        public string GoodsAirlinesCD { get; set; }

        // 도착 도시명
        public string GoodsArrivalCityNM { get; set; }

        //
        public string CityNM { get; set; }

        //
        public int RowNum { get; set; }

        //
        public string DelegateTitle { get; set; }

        // 
        public string BaseGoodsDesc { get; set; }

        // 추가 설명 1
        public string GoodsDesc1 { get; set; }

        // 추가 설명 2
        public string GoodsDesc2 { get; set; }

        // 추가 설명 3
        public string GoodsDesc3 { get; set; }

        // 추가 설명 4
        public string GoodsDesc4 { get; set; }

        // 
        public string OptImageURL { get; set; }

        //
        public string OptBenefit { get; set; }

        //
        public string OptMovieURL { get; set; }

        //
        public string GoodsGroupDesc { get; set; }

        // 상품 타입 코드 ( ex. A: 패키지, B: 자유여행 ... )
        public string GoodsTypeCD { get; set; }

        // 상품 표시 설명 1
        public string DispGoodsDesc1 { get; set; }

        // 상품 표시 설명 2
        public string DispGoodsDesc2 { get; set; }

        //
        public string DispGoodsTagNM { get; set; }
    }

    /// <summary>
    /// 환율정보
    /// </summary>
    public class ModelExchangeInfo
    {
        public int ExchangeRate { get; set; }        
    }


    /// <summary>
    /// 모바일 네비게이션 뷰 모델
    /// </summary>
    public class ModelMobileNavigation
    {
        public string TemplateURL { get; set; }
        public int CateCD { get; set; }
        public string CateNM { get; set; }
        public string lvl { get; set; }
        public string ParentCateCD { get; set; }
        public string TitleImageBig { get; set; }
        public string TitleImageSmall { get; set; }
        public string TemplateTypeCD { get; set; }
        public string GoodsViewType { get; set; }
    }

    #endregion / Data Models
}
