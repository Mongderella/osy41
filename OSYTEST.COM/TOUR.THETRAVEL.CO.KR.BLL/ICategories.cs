using TOUR.INTERPARK.COM.MODEL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOUR.INTERPARK.COM.BLL
{
    interface ICategories
    {
        ///// <summary>
        ///// Test 용 Interface
        ///// </summary>
        ///// <returns></returns>
        //List<TEST_MODEL2> GetSample();

        /// <summary>
        /// Test 용 Interface
        /// </summary>
        /// <returns></returns>
        List<TEST_MODEL2> TransactionSample_CommonSelect();

        /// <summary>
        /// Test 용 Interface
        /// </summary>
        /// <returns></returns>
        bool TransactionSample_Normal();
    }
}
