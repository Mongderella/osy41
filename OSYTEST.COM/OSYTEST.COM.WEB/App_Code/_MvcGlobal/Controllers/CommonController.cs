using System.Web.Mvc;

namespace TOUR.THETRAVEL.CO.KR.WEB.App_Code._MvcGlobal.Controllers
{
    /// <summary>
    /// Controller - 공통 
    /// </summary>
    public class CommonController : ControllerCustomBase
    {
        #region FOR FORMAL VIEW

        /// <summary>
        /// Sample
        /// </summary>
        /// <returns></returns>
        //[OutputCache(CacheProfile = "CacheProfileForCate")]
        public ActionResult Main()
        {
            #region Variables



            #endregion / Variables


            #region Load Data ( *** Static Contents Only )

            //using (TOUR.THETRAVEL.CO.KR.BLL.VIEWS_GLOBAL.Global BLL = new TOUR.THETRAVEL.CO.KR.BLL.VIEWS_GLOBAL.Global())
            //{
            //}

            #endregion / Load Data ( *** Static Contents Only )


            #region Model Assign

            //viewModelForMobile.BestSellerGoodsGroup = _bestSellerGoodsGroup;
            //viewModelForMobile.ListBanner = _listBanner;            

            #endregion / Model Assign


            return View();
        }

        #endregion / FOR FORMAL VIEW

        
        #region FOR PARTIAL VIEW

        #endregion / FOR PARTIAL VIEW


        #region CUSTOM FUNCTIONS

        #endregion / CUSTOM FUNCTIONS
    }
}