using TOUR.INTERPARK.COM.DAL;
using TOUR.INTERPARK.COM.MODEL;

using System;
using System.Collections.Generic;
using System.Transactions;

namespace TOUR.INTERPARK.COM.BLL
{
    public class Categories : ICategories, IDisposable
    {
        #region Variables

        public DAO_Sample _dao = null;
        private bool _disposed = false;

        #endregion / Variables


        #region Constructor, Deconstructor, Disposer

        public Categories()
        {
            _dao = new DAL.DAO_Sample();
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

        ~Categories()
        {
            Dispose(false);
        }

        #endregion / Constructor, Deconstructor, Disposer


        #region Methoeds For Data Access

        /// <summary>
        /// Transaction 발생 시키지 않는 Business Logic Method 작성 예
        /// </summary>
        /// <returns></returns>
        public List<TEST_MODEL2> TransactionSample_CommonSelect()
        {
            var option = new TransactionOptions
            {
                // Isolation Level 에 주의
                IsolationLevel = IsolationLevel.ReadUncommitted,
                Timeout = TransactionManager.DefaultTimeout
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress, option))
            {
                return _dao.GetMemberID();
            }
        }

        /// <summary>
        /// 복수 Transaction 발생 시키는 Business Logic Method 작성 예
        /// </summary>
        /// <returns></returns>
        public bool TransactionSample_Normal()
        {
            bool success = false;

            var option = new TransactionOptions
            {
                // Isolation Level 에 주의
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.DefaultTimeout
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress, option))
            {
                success = _dao.GetMemberID_2();

                if (success)
                    scope.Complete();

                return true;
            }

        }


        #endregion / Methoeds For Data Access
    }
}
