using TOUR.THETRAVEL.CO.KR.DAL;
using TOUR.THETRAVEL.CO.KR.MODEL;

using System;
using System.Collections.Generic;
using System.Transactions;

namespace TOUR.THETRAVEL.CO.KR.BLL.VIEWS
{
    public class Sample : IDisposable
    {
        #region Variables

        public DAO_Global _dao = null;
        private bool _disposed = false;

        #endregion / Variables


        #region Constructor, Deconstructor, Disposer

        public Sample()
        {
            _dao = new DAL.DAO_Global();
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

        ~Sample()
        {
            Dispose(false);
        }

        #endregion / Constructor, Deconstructor, Disposer


        #region Methoeds For Data Access

        // To Do...

        #endregion / Methoeds For Data Access
    }
}
