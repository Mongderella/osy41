using TOUR.THETRAVEL.CO.KR.MODEL.UTIL;
using Newtonsoft.Json;
using System;

namespace TOUR.THETRAVEL.CO.KR.MODEL.VIEWS_GLOBAL.ViewModelsSample_Mobile
{
    /* For Any Controller ( Controller / View 에 종속적이지 않은 공통 Model ) */

    #region View Models

    /// <summary>
    /// Touradmin -> 메인 -> 공통_상세배너관리 / 공통_상세배너조회 에서 사용
    /// </summary>
    public class ViewModelBannerWithConditions
    {
        // 배너 고유 Seq
        [JsonIgnore]
        int BannerNo { get; set; }

        // 배너 등록명
        [JsonProperty("Banner_N")]
        string BannerNM { get; set; }

        //
        [JsonIgnore]
        string OpenLocCD { get; set; }

        // 배너 이미지 경로
        [JsonProperty("Image_U")]
        string ImageURL { get; set; }

        // 배너 Link URL
        [JsonProperty("Lk")]
        string Link { get; set; }

        // 배너 Link 클릭 시, 새창 여부
        [JsonIgnore]
        string LinkNewWindowYN { get; set; }
    }

    /// <summary>
    /// HTML
    /// </summary>
    public class ViewModelHtml
    {
        [JsonProperty("Contents_U_Y")]
        public string ContentsUseYN { get; set; }
        [JsonProperty("Ctt")]
        public string Contents { get; set; }
        [JsonProperty("Contents_U_Y_S")]
        public string ContentsUseYN_Sub { get; set; }
        [JsonProperty("Contents_S")]
        public string Contents_Sub { get; set; }
    }

    /// <summary>
    /// 공통 - 이벤트 기획전 배너 
    /// </summary>
    public class ViewModelEventBanner
    {
        [JsonProperty("Pc_I")]
        public string PcImage { get; set; }

        [JsonProperty("Mobile_I")]
        public string MobileImage { get; set; }

        // ModelEventBanner 의 TophtmlYN 의 값에 따라 Redirect 주소 또는 Tour 의 이벤트 주소를 할당한다.
        [JsonProperty("Link_U")]
        public string LinkUrl { get; set; }

        //
        [JsonProperty("Redrect_U")]
        public string RedirectionURL { get; set; }

        // 이벤트명
        [JsonProperty("Promotion_T")]
        public string PromotionTitle { get; set; }
    }

    /// <summary>
    /// 모바일 네비게이션 뷰 모델
    /// </summary>
    public class ViewModelMobileNavigation
    {
        public int CateCD { get; set; }
        public string CateNM { get; set; }
        public string Lvl { get; set; }
    }

    #endregion / View Models
}
