using TOUR.THETRAVEL.CO.KR.MODEL.VIEWS.ViewModelsCommon_Mobile;
using TOUR.THETRAVEL.CO.KR.MODEL.DATA.ModelsCommon_Mobile;

using System;
using System.Collections.Generic;
using System.Transactions;
using TOUR.THETRAVEL.CO.KR.DAL;
using TOUR.THETRAVEL.CO.KR.MODEL;

namespace TOUR.THETRAVEL.CO.KR.BLL.DATA
{
    public class Common : IDisposable
    {
        #region Variables

        public DAO_Common _dao = null;
        private bool _disposed = false;

        #endregion / Variables


        #region Constructor, Deconstructor, Disposer

        public Common()
        {
            _dao = new DAL.DAO_Common();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _dao.Dispose();
            }

            _disposed = true;
        }

        ~Common()
        {
            Dispose(false);
        }

        #endregion / Constructor, Deconstructor, Disposer


        #region Methoeds For Data Access


        /// <summary>
        /// 상품검색 기초상품 리스트 조회        
        /// </summary>
        public List<ViewModelSearchBaseGoodsList> GetSearchBaseGoodsList(string cateCD, string baseGoodsNM, string departureDT, string startDT, string endDT, int dayCntFrom, int dayCntTo, int adultRateFrom, int adultRateTo, string sort, int pageSize, int pageNum, string fromMobileYN)
        {
            var option = new TransactionOptions
            {
                // Isolation Level 에 주의
                IsolationLevel = IsolationLevel.ReadUncommitted,
                Timeout = TransactionManager.DefaultTimeout
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress, option))
            {
                // 출발상품 정보 조회 및 맵핑
                List<ModelSearchBaseGoodsList> tmpList = _dao.GetSearchBaseGoodsList(cateCD, baseGoodsNM, departureDT, startDT, endDT, dayCntFrom, dayCntTo, adultRateFrom, adultRateTo, sort, pageSize, pageNum, fromMobileYN);
                List<ViewModelSearchBaseGoodsList> returnResult = new List<ViewModelSearchBaseGoodsList>();

                if (tmpList != null && tmpList.Count > 0)
                {
                    foreach (ModelSearchBaseGoodsList n in tmpList)
                    {
                        ViewModelSearchBaseGoodsList obj = new ViewModelSearchBaseGoodsList();

                        obj.ListCnt = n.ListCnt;
                        obj.CateCD = n.CateCD;
                        obj.GoodsNM = n.GoodsNM;
                        obj.DispGoodsNMSub = n.DispGoodsNMSub;
                        obj.DispGoodsNM = n.DispGoodsNM;
                        obj.BaseGoodsCD = n.BaseGoodsCD;
                        obj.AdultRate = n.AdultRate;
                        obj.SupplierCD = n.SupplierCD;
                        obj.ImageFileNM = n.ImageFileNM;
                        obj.RowNum = n.RowNum;
                        obj.GoodsDesc = n.GoodsDesc;
                        obj.TrafficRetTripNM = n.TrafficRetTripNM;
                        obj.GoodsDesc1 = n.GoodsDesc1;
                        obj.GoodsDesc2 = n.GoodsDesc2;
                        obj.GoodsDesc3 = n.GoodsDesc3;
                        obj.GoodsDesc4 = n.GoodsDesc4;

                        returnResult.Add(obj);
                    }
                }

                return returnResult;
            }
        }


        /// <summary>
        /// 상품검색 기초상품 리스트 조회        
        /// </summary>
        public List<ViewModelSearchBaseGoodsList> GetSearchThemeTourBaseGoodsList(string cateCD, string baseGoodsNM, string departureDT, int dayCntFrom, int dayCntTo, int adultRateFrom, int adultRateTo, string sort, int pageSize, int pageNum)
        {
            var option = new TransactionOptions
            {
                // Isolation Level 에 주의
                IsolationLevel = IsolationLevel.ReadUncommitted,
                Timeout = TransactionManager.DefaultTimeout
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress, option))
            {
                // 출발상품 정보 조회 및 맵핑
                List<ModelSearchBaseGoodsList> tmpList = _dao.GetSearchThemeTourBaseGoodsList(cateCD, baseGoodsNM, departureDT, dayCntFrom, dayCntTo, adultRateFrom, adultRateTo, sort, pageSize, pageNum);
                List<ViewModelSearchBaseGoodsList> returnResult = new List<ViewModelSearchBaseGoodsList>();

                if (tmpList != null && tmpList.Count > 0)
                {
                    foreach (ModelSearchBaseGoodsList n in tmpList)
                    {
                        ViewModelSearchBaseGoodsList obj = new ViewModelSearchBaseGoodsList();

                        obj.ListCnt = n.ListCnt;
                        obj.CateCD = n.CateCD;
                        obj.GoodsNM = n.GoodsNM;
                        obj.DispGoodsNMSub = n.DispGoodsNMSub;
                        obj.DispGoodsNM = n.DispGoodsNM;
                        obj.BaseGoodsCD = n.BaseGoodsCD;
                        obj.AdultRate = n.AdultRate;
                        obj.SupplierCD = n.SupplierCD;
                        obj.ImageFileNM = n.ImageFileNM;
                        obj.RowNum = n.RowNum;
                        obj.GoodsDesc = n.GoodsDesc;
                        obj.TrafficRetTripNM = n.TrafficRetTripNM;
                        obj.GoodsDesc1 = n.GoodsDesc1;
                        obj.GoodsDesc2 = n.GoodsDesc2;
                        obj.GoodsDesc3 = n.GoodsDesc3;
                        obj.GoodsDesc4 = n.GoodsDesc4;

                        returnResult.Add(obj);
                    }
                }

                return returnResult;
            }
        }


        /// <summary>
        /// 상품검색 기초상품 리스트 조회        
        /// </summary>
        public List<ViewModelSearchGoodsList> GetSearchDomesticThisWeekGoodsList(string cateCD, string baseGoodsNM, string trafficCD, int dayCntFrom, int dayCntTo, int adultRateFrom, int adultRateTo, int pageSize, int pageNum)
        {
            var option = new TransactionOptions
            {
                // Isolation Level 에 주의
                IsolationLevel = IsolationLevel.ReadUncommitted,
                Timeout = TransactionManager.DefaultTimeout
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress, option))
            {
                // 출발상품 정보 조회 및 맵핑
                List<ModelSearchDomesticThisWeekBaseGoodsList> tmpList = _dao.GetSearchDomesticThisWeekBaseGoodsList(cateCD, baseGoodsNM, trafficCD, dayCntFrom, dayCntTo, adultRateFrom, adultRateTo, pageSize, pageNum);
                List<ViewModelSearchGoodsList> returnResult = new List<ViewModelSearchGoodsList>();

                if (tmpList != null && tmpList.Count > 0)
                {
                    foreach (ModelSearchDomesticThisWeekBaseGoodsList n in tmpList)
                    {
                        ViewModelSearchGoodsList obj = new ViewModelSearchGoodsList();

                        obj.ListCnt = n.ListCnt;
                        obj.CateCD = n.CateCD;
                        obj.GoodsNM = n.GoodsNM;
                        obj.DispGoodsNMSub = n.GoodsDesc;
                        obj.DispGoodsNM = n.GoodsNM;
                        obj.GoodsCD = n.GoodsCD;
                        obj.BaseGoodsCD = n.BaseGoodsCD;
                        obj.AdultRate = n.AdultRate;
                        obj.SupplierCD = n.SupplierCD;
                        obj.ImageFileNM = n.FileNM;
                        obj.RowNum = n.RowNum;
                        obj.GoodsDesc = n.GoodsDesc;
                        obj.TrafficRetTripNM = "";
                        obj.GoodsDesc1 = "";
                        obj.GoodsDesc2 = "";
                        obj.GoodsDesc3 = "";
                        obj.GoodsDesc4 = "";

                        returnResult.Add(obj);
                    }
                }

                return returnResult;
            }
        }

        #endregion / Methoeds For Data Access
    }
}
