using TOUR.THETRAVEL.CO.KR.MODEL.VIEWS_GLOBAL.ViewModelsGlobal_Mobile;
using TOUR.THETRAVEL.CO.KR.MODEL.DATA_GLOBAL.ModelsSample_Mobile;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;



namespace TOUR.THETRAVEL.CO.KR.DAL
{
    public class DAO_Global : DAO_Base
    {
        public DAO_Global()
        {
            
        }

        /// <summary>
        /// 인자에 해당하는 전시 카테고리 정보를 반환합니다.
        /// </summary>
        /// <param name="cateCD"></param>
        /// <returns></returns>
        public List<ModelExhibitInformation> GetExhibitInformationByCategoryCD(int cateCD)
        {
            var dbArgs = new DynamicParameters();
            dbArgs.Add("@CateCD", cateCD);

            var returnResult = _dbConn.Query<ModelExhibitInformation>("usp_FR_Exibit_Category_GetList_TYPE_4", dbArgs, commandType: CommandType.StoredProcedure).ToList();

            return returnResult;
        }

        /// <summary>
        /// 인자에 해당하는 상세 배너 리스트
        /// </summary>
        /// <param name="ApplSystemCD"></param>
        /// <param name="AreaCD"></param>
        /// <param name="GoodsTypeCD"></param>
        /// <param name="BaseGoodsCD"></param>
        /// <param name="GoodsCD"></param>
        /// <param name="SupplierCD"></param>
        /// <param name="NatCD_List"></param>
        /// <param name="CityCD_List"></param>
        /// <param name="StartDate"></param>
        /// <param name="CurrentCateCD"></param>
        /// <returns></returns>
        public List<ViewModelBannerWithConditions> GetGoodsBannerWithConditions(string applSystemCD, string areaCD, string goodsTypeCD, string baseGoodsCD, string goodsCD, string supplierCD, string natCD_List, string cityCD_List, string startDate, string ippId, string exposeType, int currentCateCD)
        {
            var dbArgs = new DynamicParameters();
            dbArgs.Add("@CateCD", applSystemCD);
            dbArgs.Add("@Area", areaCD);
            dbArgs.Add("@GoodsType", goodsTypeCD);
            dbArgs.Add("@GoosCD", baseGoodsCD);
            dbArgs.Add("@GoodsDeatilCD", goodsCD);
            dbArgs.Add("@Corp", supplierCD);
            dbArgs.Add("@NatCD", natCD_List);
            dbArgs.Add("@CityCD", cityCD_List);
            dbArgs.Add("@PlayDate", startDate);
            dbArgs.Add("@IPPID", ippId);
            dbArgs.Add("@OpenLocCD", exposeType);
            dbArgs.Add("@CurrentCateCD", currentCateCD);

            var returnResult = _dbConn.Query<ViewModelBannerWithConditions>("usp_FR_Banner_Exibit_List", dbArgs, commandType: CommandType.StoredProcedure).ToList();

            return returnResult;
        }

        /// <summary>
        /// 인자에 해당하는 상단 / 하단 Html 정보를 반환합니다.
        /// </summary>
        /// <param name="pageGroupCD"></param>
        /// <param name="cateCD"></param>
        /// <returns></returns>
        public ModelHtml GetHtmlContents(int pageGroupCD, int cateCD, string isMobile)
        {
            var dbArgs = new DynamicParameters();
            dbArgs.Add("@PageGroupCD", pageGroupCD);
            dbArgs.Add("@CateCD", cateCD);

            if(!string.IsNullOrEmpty(isMobile))
                dbArgs.Add("@MobileYN", isMobile);

            var returnResult = _dbConn.Query<ModelHtml>("usp_FR_Page_Contents_List", dbArgs, commandType: CommandType.StoredProcedure).FirstOrDefault();

            return returnResult;
        }

        /// <summary>
        /// 인자에 해당하는 KeywordLink 정보를 반환합니다.
        /// </summary>
        /// <param name="pageGroupCD"></param>
        /// <param name="cateCD"></param>
        /// <param name="tagGroupSeq"></param>
        /// <returns></returns>
        public List<ModelKeywordLink> GetKeywordLink(int pageGroupCD, int cateCD, int? tagGroupSeq)
        {
            var dbArgs = new DynamicParameters();
            dbArgs.Add("@PageGroupCD", pageGroupCD);
            dbArgs.Add("@CateCD", cateCD);

            if (tagGroupSeq != null)
                dbArgs.Add("@TagGroupSeq", tagGroupSeq);

            var returnResult = _dbConn.Query<ModelKeywordLink>("usp_Fr_PageKeyword_List", dbArgs, commandType: CommandType.StoredProcedure).ToList();

            return returnResult;
        }

        /// <summary>
        /// 인자에 해당하는 이벤트 배너 정보를 반환합니다.
        /// </summary>
        /// <param name="pageGroupCD"></param>
        /// <param name="exhibitYN"></param>
        /// <param name="pcExposeYN"></param>
        /// <param name="mobileExposeYN"></param>
        /// <param name="cateCD"></param>
        /// <returns></returns>
        public List<ModelEventBanner> GetEventBanners(int pageGroupCD, string exhibitYN, string pcExposeYN, string mobileExposeYN, int? cateCD)
        //public List<ModelEventBanner> GetEventBanners(PramModelEventBannerList parameters)
        {
            int tmpOut = 0;

            var dbArgs = new DynamicParameters();
            dbArgs.Add("@BannerCnt", tmpOut);
            dbArgs.Add("@PageGroupCD", pageGroupCD);

            if(!string.IsNullOrEmpty(exhibitYN))
                dbArgs.Add("@ExibitYN", exhibitYN);

            if (pcExposeYN != null)
                dbArgs.Add("@PCExposeYN", pcExposeYN);

            if (!string.IsNullOrEmpty(mobileExposeYN))
                dbArgs.Add("@MobileExposeYN", mobileExposeYN);

            if (cateCD != null)
                dbArgs.Add("@CateCD", cateCD);

            var returnResult = _dbConn.Query<ModelEventBanner>("usp_FR_Promotion_Main_Banner", dbArgs, commandType: CommandType.StoredProcedure).ToList();

            return returnResult;
        }

        /// <summary>
        /// 인자에 해당하는 상품 그룹 정보를 반환합니다. ( ViewModelGoodsGroup 을 위함 )
        /// </summary>
        /// <param name="pageGroupCD"></param>
        /// <param name="cateCD"></param>
        /// <param name="seq"></param>
        /// <returns></returns>
        public List<ModelGoodsGroup> GetGoodsGroup(int pageGroupCD, int cateCD, int seq)
        {
            var dbArgs = new DynamicParameters();
            dbArgs.Add("@pageGroupCD", pageGroupCD);
            dbArgs.Add("@cateCD", cateCD);
            dbArgs.Add("@seq", seq);

            var returnResult = _dbConn.Query<ModelGoodsGroup>("usp_FR_Product_Exbit_List", dbArgs, commandType: CommandType.StoredProcedure).ToList();

            return returnResult;
        }

        /// <summary>
        /// 환율금액조회
        /// </summary>        
        public List<ModelExchangeInfo> GetExhangeInfo(string currencyCD)
        {
            var dbArgs = new DynamicParameters();
            dbArgs.Add("@CurrencySign", currencyCD);

            var returnResult = _dbConn.Query<ModelExchangeInfo>("usp_FR_ExchangeInfo_GetRate", dbArgs, commandType: CommandType.StoredProcedure).ToList();

            return returnResult;
        }


        /// <summary>
        /// 카테고리 경로 조회
        /// </summary>
        /// <param name="cateCD"></param>
        /// <returns></returns>
        public List<ModelMobileNavigation> GetCategoryDepthList(int cateCD)
        {
            var dbArgs = new DynamicParameters();
            dbArgs.Add("@CateCD", cateCD);

            return _dbConn.Query<ModelMobileNavigation>("usp_FR_Exibit_Category_GetList_TYPE_4", dbArgs, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
