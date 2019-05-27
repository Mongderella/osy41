using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOUR.THETRAVEL.CO.KR.MODEL.DATA.ModelsSample_Mobile
{

    #region Data Models


    /// <summary>
    /// 기초상품 리스트 모델
    /// GetSearchBaseGoodsList
    /// </summary>
    public class ModelSearchBaseGoodsList
    {
        public int ListCnt { get; set; }

        public int RowNum { get; set; }

        //public int SEQ { get; set; }

        public int CateCD { get; set; }

        public string BaseGoodsCD { get; set; }

        public string StartDT { get; set; }

        public string EndDT { get; set; }

        public string GoodsNM { get; set; }

        public string BundleGoodsYN { get; set; }

        public int AdultRate { get; set; }

        public int MaxAdultRate { get; set; }

        //public int ReserveRate { get; set; }

        public int EvalPointAvg { get; set; }

        public string ImageFileNM { get; set; }

        public int NightCnt { get; set; }

        public int DayCnt { get; set; }

        public string SupplierCD { get; set; }

        public string GoodsDesc { get; set; }

        public string DispGoodsNM { get; set; }

        public string TrafficRetTripNM { get; set; }

        public string DispGoodsNMSub { get; set; }
        
        public string GoodsDesc1 { get; set; }

        public string GoodsDesc2 { get; set; }

        public string GoodsDesc3 { get; set; }

        public string GoodsDesc4 { get; set; }
 
    }


    public class ModelSearchDomesticThisWeekBaseGoodsList
    {
        public int ListCnt { get; set; }

        public int RowNum { get; set; }

        public int CateCD { get; set; }

        public string GoodsCD { get; set; }

        public string BaseGoodsCD { get; set; }

        public string DepartureDT { get; set; }

        public string ArrivalDT { get; set; }

        public string GoodsNM { get; set; }

        public int AdultRate { get; set; }        

        public string FileNM { get; set; }

        public int NightCnt { get; set; }

        public int DayCnt { get; set; }

        public string SupplierCD { get; set; }

        public string GoodsDesc { get; set; }
    }


    #endregion / Data Models
}
