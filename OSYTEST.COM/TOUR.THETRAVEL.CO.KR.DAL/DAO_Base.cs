using INTERPARKTOUR.DAL.BASE;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOUR.THETRAVEL.CO.KR.DAL
{
    public class DAO_Base : IDisposable
    {
        #region Variables

        protected DataAccessLayer _dal = null;
        protected IDbConnection _dbConn = null;
        private bool _disposed = false;

        #endregion / Variables


        #region Constructor, Deconstructor, Disposer

        public DAO_Base() : this("tour")
        {
        }

        public DAO_Base(string connectionAlias)
        {
            _dal = new DataAccessLayer(connectionAlias);
            _dbConn = _dal.GetConnectionByAlias();
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
                _dbConn.Dispose();
            }

            _disposed = true;
        }

        ~DAO_Base()
        {
            Dispose(false);
        }

        #endregion / Constructor, Deconstructor, Disposer
    }
}
