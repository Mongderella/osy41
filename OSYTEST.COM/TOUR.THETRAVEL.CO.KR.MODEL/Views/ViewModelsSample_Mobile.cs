using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOUR.THETRAVEL.CO.KR.MODEL.UTIL;
using TOUR.THETRAVEL.CO.KR.MODEL.VIEWS_GLOBAL.ViewModelsGlobal_Mobile;

namespace TOUR.THETRAVEL.CO.KR.MODEL.VIEWS.ViewModelsSample_Mobile
{
    /* For CommonController */

    #region View Models

    public class ViewModelD1
    {
        public List<ViewModelEventBanner> EventBannerList { get; set; }

        public List<ViewModelGoodsGroup> GoodsGroupMobileSpecialPrice { get; set; }

        public List<ViewModelKeywordLink> KeywordLinkTop { get; set; }

        public List<ViewModelKeywordLink> KeywordLinkMiddle { get; set; }

        public List<ViewModelKeywordLink> KeywordLinkBottom { get; set; }

        public List<List<ViewModelGoodsGroup>> GoodsGroupsForTagSection { get; set; }

        public ViewModelHtml HtmlTopAndBottom { get; set; }
    }

    /// <summary>
    /// 모바일 리스트 ViewModel
    /// </summary>
    public class ViewModelList
    {

        public List<ViewModelGoodsGroup> BestSellerGoodsGroup { get; set; }

        public ViewModelBannerWithConditions ListBanner { get; set; }
        
    }


    /// <summary>
    /// 기초상품 리스트 ViewModel
    /// 상세검색 - 검색 결과 리스트
    /// </summary>
    public class ViewModelSearchBaseGoodsList
    {
        // 카테고리 CD
        [JsonProperty("List_C")]
        public int ListCnt { get; set; }

        // 카테고리 CD
        [JsonProperty("Cate_C")]
        public int CateCD { get; set; }

        // 상품명
        [JsonProperty("Goods_N")]
        public string GoodsNM { get; set; }

        // 상품 서브 이름
        [JsonProperty("Disp_G_N_S")]
        public string DispGoodsNMSub { get; set; }

        // 노출 상품 명
        [JsonProperty("Disp_G_N")]
        public string DispGoodsNM { get; set; }

        // 기초상품코드
        [JsonProperty("Base_G_C")]
        public string BaseGoodsCD { get; set; }

        // 성인 가격
        [JsonProperty("Adult_R")]
        public int AdultRate { get; set; }

        // 공급사 코드
        [JsonProperty("Supplier_C")]
        public string SupplierCD { get; set; }

        // 이미지 파일명
        [JsonProperty("Image_F_N")]
        public string ImageFileNM { get; set; }

        [JsonIgnore]
        public int RowNum { get; set; }

        // 상품 설명
        [JsonProperty("Goods_D")]
        public string GoodsDesc { get; set; }

        // 교통
        [JsonProperty("Traffic_R_T_N")]
        public string TrafficRetTripNM { get; set; }

        // 상품 설명1
        [JsonProperty("Goods_D1")]
        public string GoodsDesc1 { get; set; }

        // 상품 설명2
        [JsonProperty("Goods_D2")]
        public string GoodsDesc2 { get; set; }

        // 상품 설명3
        [JsonProperty("Goods_D3")]
        public string GoodsDesc3 { get; set; }

        // 상품 설명4
        [JsonProperty("Goods_D4")]
        public string GoodsDesc4 { get; set; }

        // 상품 이미지 ( 리스트용 280 px )
        [JsonProperty("Image_U_F_L")]
        public string ImageUrlForList
        {
            get
            {
                return ModelUtility.GetPrdImgURL(SupplierCD, BaseGoodsCD, "280", ImageFileNM);
            }

            set { }
        }
    }

    public class ViewModelSearchGoodsList : ViewModelSearchBaseGoodsList
    {
        // 기초상품코드
        [JsonProperty("Goods_C")]
        public string GoodsCD { get; set; }
    }

    #endregion / View Models
}
