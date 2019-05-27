using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOUR.THETRAVEL.CO.KR.MODEL.UTIL
{
    public class ModelUtility
    {
        #region Custom Method 

        /// <summary>
        /// Sample
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public static string GetMoneyFormat(int money)
        {
            return string.Format("{0:n0}", money);
        }

        #endregion / Custom Method
    }
}
