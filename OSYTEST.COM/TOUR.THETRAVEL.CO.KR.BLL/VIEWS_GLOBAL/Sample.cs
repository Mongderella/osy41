using TOUR.THETRAVEL.CO.KR.DAL;
using TOUR.THETRAVEL.CO.KR.MODEL.DATA_GLOBAL.ModelsGlobal_Mobile;
using TOUR.THETRAVEL.CO.KR.MODEL.VIEWS_GLOBAL.ViewModelsGlobal_Mobile;

using System;
using System.Collections.Generic;
using System.Transactions;
using TOUR.THETRAVEL.CO.KR.MODEL.PARAMETER;
using TOUR.THETRAVEL.CO.KR.MODEL.DATA.ModelsGoods_Mobile;
using TOUR.THETRAVEL.CO.KR.MODEL.VIEWS;
using System.Globalization;
using TOUR.THETRAVEL.CO.KR.MODEL.VIEWS.ViewModelsSharedControl_Mobile;


namespace TOUR.THETRAVEL.CO.KR.BLL.VIEWS_GLOBAL
{
    public class Sample : IDisposable
    {
        #region Variables

        public DAO_Global _daoGlobal = null;
        private bool _disposed = false;

        #endregion / Variables


        #region Constructor, Deconstructor, Disposer

        public Sample()
        {
            _daoGlobal = new DAO_Global();
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
                _daoGlobal.Dispose();
            }

            _disposed = true;
        }

        ~Sample()
        {
            Dispose(false);
        }

        #endregion / Constructor, Deconstructor, Disposer


        #region Methoeds For Data Access

        /// <summary>
        /// 카테고리에 해당하는 전시 정보들을 반환합니다.
        /// </summary>
        /// <param name="cateCD"></param>
        /// <returns></returns>
        public ModelExhibitInformation GetExhibitInformationByCategoryCD(int cateCD)
        {
            var option = new TransactionOptions
            {
                // Isolation Level 에 주의
                IsolationLevel = IsolationLevel.ReadUncommitted,
                Timeout = TransactionManager.DefaultTimeout
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress, option))
            {
                List<ModelExhibitInformation> tmpList = _daoGlobal.GetExhibitInformationByCategoryCD(cateCD);
                ModelExhibitInformation returnResult = null;

                if (tmpList.Count > 0)
                {
                    returnResult = tmpList[tmpList.Count - 1];
                }

                return returnResult;
            }
        }

        /// <summary>
        /// 인자에 해당하는 조건으로 설정된 상세 배너를 1개 반환합니다.
        /// </summary>
        /// <param name="applSystemCD"></param>
        /// <param name="areaCD"></param>
        /// <param name="goodsTypeCD"></param>
        /// <param name="baseGoodsCD"></param>
        /// <param name="goodsCD"></param>
        /// <param name="supplierCD"></param>
        /// <param name="natCD_List"></param>
        /// <param name="cityCD_List"></param>
        /// <param name="startDate"></param>
        /// <param name="ippId"></param>
        /// <param name="currentCateCD"></param>
        /// <returns></returns>
        public ViewModelBannerWithConditions GetSingleGoodsBannerWithConditions(string applSystemCD, string areaCD, string goodsTypeCD, string baseGoodsCD, string goodsCD, string supplierCD, string natCD_List, string cityCD_List, string startDate, string ippId, string exposeType, int currentCateCD)
        {
            var option = new TransactionOptions
            {
                // Isolation Level 에 주의
                IsolationLevel = IsolationLevel.ReadUncommitted,
                Timeout = TransactionManager.DefaultTimeout
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress, option))
            {
                List<ViewModelBannerWithConditions> tmpList = _daoGlobal.GetGoodsBannerWithConditions(applSystemCD, areaCD, goodsTypeCD, baseGoodsCD, goodsCD, supplierCD, natCD_List, cityCD_List, startDate, ippId, exposeType, currentCateCD);
                ViewModelBannerWithConditions returnResult = null;

                if (tmpList != null)
                {
                    Random random = new Random();

                    int randomNum = 0;

                    if (tmpList.Count > 0)
                    {
                        randomNum = random.Next(0, tmpList.Count - 1);
                        returnResult = tmpList[randomNum];
                    }
                }

                return returnResult;
            }
        }

        /// <summary>
        /// 인자에 해당하는 조건의 Html Contents 를 반환합니다.
        /// </summary>
        /// <param name="pageGroupCD"></param>
        /// <param name="cateCD"></param>
        /// <param name="isMobile"></param>
        /// <returns></returns>
        public ViewModelHtml GetHtmlContents(int pageGroupCD, int cateCD, string isMobile)
        {
            var option = new TransactionOptions
            {
                // Isolation Level 에 주의
                IsolationLevel = IsolationLevel.ReadUncommitted,
                Timeout = TransactionManager.DefaultTimeout
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress, option))
            {
                ModelHtml tmpList = _daoGlobal.GetHtmlContents(pageGroupCD, cateCD, isMobile);
                ViewModelHtml returnResult = new ViewModelHtml();

                if (tmpList != null)
                {
                    returnResult.ContentsUseYN = tmpList.ContentsUseYN;
                    returnResult.Contents = tmpList.Contents;
                    returnResult.ContentsUseYN_Sub = tmpList.ContentsUseYN_Sub;
                    returnResult.Contents_Sub = tmpList.Contents_Sub;
                }

                return returnResult;
            }
        }

        /// <summary>
        /// 인자에 해당하는 KeywordLink 정보를 반환합니다.
        /// </summary>
        /// <param name="pageGroupCD"></param>
        /// <param name="cateCD"></param>
        /// <param name="tagGroupSeq">인자로 넘기지 않을 경우, seq 를 무시하고 pageGroupCD, cateCD 해당 데이터 모두 조회</param>
        /// <returns></returns>
        public List<ViewModelKeywordLink> GetKeywordLink(int pageGroupCD, int cateCD, int? tagGroupSeq)
        {
            var option = new TransactionOptions
            {
                // Isolation Level 에 주의
                IsolationLevel = IsolationLevel.ReadUncommitted,
                Timeout = TransactionManager.DefaultTimeout
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress, option))
            {
                List<ModelKeywordLink> tmpList = _daoGlobal.GetKeywordLink(pageGroupCD, cateCD, tagGroupSeq);
                List<ViewModelKeywordLink> returnResult = new List<ViewModelKeywordLink>();

                if (tmpList != null && tmpList.Count > 0)
                {
                    foreach (ModelKeywordLink n in tmpList)
                    {
                        ViewModelKeywordLink obj = new ViewModelKeywordLink();

                        obj.ImageURL = n.ImageURL;
                        obj.Keyword = n.Keyword;
                        obj.KeywordA = n.KeywordA;
                        obj.KeywordB = n.KeywordB;
                        obj.LinkURL = n.LinkURL;
                        obj.PageGroupCD = n.PageGroupCD;
                        obj.TagGroupSeq = n.TagGroupSeq;

                        returnResult.Add(obj);
                    }
                }

                return returnResult;
            }
        }

        /// <summary>
        /// 인자에 해당하는 이벤트 기획전 배너를 반환합니다.
        /// </summary>
        /// <param name="pageGroupCD"></param>
        /// <param name="exhibitYN"></param>
        /// <param name="pcExposeYN"></param>
        /// <param name="mobileExposeYN"></param>
        /// <param name="cateCD"></param>
        /// <returns></returns>
        public List<ViewModelEventBanner> GetEventBanners(int pageGroupCD, string exhibitYN, string pcExposeYN, string mobileExposeYN, int? cateCD)
        //public List<ViewModelEventBanner> GetEventBanners(PramModelEventBannerList parameters)
        {
            var option = new TransactionOptions
            {
                // Isolation Level 에 주의
                IsolationLevel = IsolationLevel.ReadUncommitted,
                Timeout = TransactionManager.DefaultTimeout
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress, option))
            {
                List<ModelEventBanner> tmpList = _daoGlobal.GetEventBanners(pageGroupCD, exhibitYN, pcExposeYN, mobileExposeYN, cateCD);
                List<ViewModelEventBanner> returnResult = new List<ViewModelEventBanner>();

                if (tmpList != null && tmpList.Count > 0)
                {
                    foreach (ModelEventBanner n in tmpList)
                    {
                        ViewModelEventBanner obj = new ViewModelEventBanner();

                        // TopHtmlYN 의 값에 따라, LinkUrl 을 분기
                        string tmpLinkUrl = string.Empty;

                        if (n.TopHtmlYN == "P" || n.TopHtmlYN == "N")
                            tmpLinkUrl = n.RedirectionURL;
                        else
                        {
                            if(pcExposeYN.ToUpper().Equals("Y") && (mobileExposeYN.ToUpper().Equals("N") || string.IsNullOrEmpty(mobileExposeYN)))
                                tmpLinkUrl = "http://TOUR.THETRAVEL.CO.KR/event/event_view.aspx?seq=" + n.PromotionSeq;

                            if(mobileExposeYN.ToUpper().Equals("Y") && (pcExposeYN.ToUpper().Equals("N") || string.IsNullOrEmpty(pcExposeYN)))
                                tmpLinkUrl = "http://mTOUR.THETRAVEL.CO.KR/event.aspx?seq=" + n.PromotionSeq;
                        }

                        obj.PcImage = "http://tourimage.interpark.com/Sites/Tour/Event/Main/" +  n.ListImage;
                        obj.MobileImage = "http://tourimage.interpark.com/Sites/Tour/Event/Main/" + n.MobileImage;
                        obj.LinkUrl = tmpLinkUrl;
                        obj.RedirectionURL = n.RedirectionURL;
                        obj.PromotionTitle = n.PromotionTitle;

                        returnResult.Add(obj);
                    }
                }

                return returnResult;
            }
        }


        /// <summary>
        /// 인자에 해당하는 상품 그룹 정보를 반환합니다. ( For View )
        /// </summary>
        /// <param name="pageGroupCD"></param>
        /// <param name="cateCD"></param>
        /// <param name="seq"></param>
        /// <returns></returns>
        public List<ViewModelGoodsGroup>GetGoodsGroup(int pageGroupCD, int cateCD, int seq)
        {
            var option = new TransactionOptions
            {
                // Isolation Level 에 주의
                IsolationLevel = IsolationLevel.ReadUncommitted,
                Timeout = TransactionManager.DefaultTimeout
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress, option))
            {
                List<ModelGoodsGroup> tmpList = _daoGlobal.GetGoodsGroup(pageGroupCD, cateCD, seq);
                List<ViewModelGoodsGroup> returnResult = new List<ViewModelGoodsGroup>();

                if (tmpList != null && tmpList.Count > 0)
                {
                    foreach (ModelGoodsGroup n in tmpList)
                    {
                        ViewModelGoodsGroup obj = new ViewModelGoodsGroup();

                        obj.GoodsType = n.GoodsType;
                        obj.DispGoodsNM = n.DispGoodsNM;
                        obj.AddValue1 = n.AddValue1;
                        obj.AddValue2 = n.AddValue2;
                        obj.BaseGoodsCD = n.BaseGoodsCD;
                        obj.GoodsCD = n.GoodsCD;
                        obj.CateCD = n.CateCD;
                        obj.BundleGoodsYN = n.BundleGoodsYN;
                        obj.MinAdultRate = n.MinAdultRate;
                        obj.GoodsDesc1 = n.GoodsDesc1;
                        obj.GoodsDesc2 = n.GoodsDesc2;
                        obj.GoodsDesc3 = n.GoodsDesc3;
                        obj.GoodsDesc4 = n.GoodsDesc4;
                        //obj.ImageUrlForList = n.ImageUrl;
                        obj.GoodsGroupDesc = n.GoodsGroupDesc;
                        obj.SupplierCD = n.SupplierCD;
                        obj.FILENM = n.FILENM;
                        
                        returnResult.Add(obj);
                    }
                }

                return returnResult;
            }
        }


        /// <summary>
        /// 모바일 네비게이션 루트 정보 조회
        /// </summary>        
        public List<ViewModelMobileNavigation> GetCategoryDepthList(int cateCD)
        {
            var option = new TransactionOptions
            {
                // Isolation Level 에 주의
                IsolationLevel = IsolationLevel.ReadUncommitted,
                Timeout = TransactionManager.DefaultTimeout
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress, option))
            {
                List<ModelMobileNavigation> tmpList = _daoGlobal.GetCategoryDepthList(cateCD);
                List<ViewModelMobileNavigation> returnResult = new List<ViewModelMobileNavigation>();

                if (tmpList != null)
                {
                    foreach (ModelMobileNavigation n in tmpList)
                    {
                        ViewModelMobileNavigation obj = new ViewModelMobileNavigation();

                        obj.CateCD = n.CateCD;
                        obj.CateNM = n.CateNM;
                        obj.Lvl = n.lvl;

                        returnResult.Add(obj);
                    }
                }

                return returnResult;
            }
        }

        #endregion / Methoeds For Data Access

    }
    
}
