using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prototype.EF.Models;

namespace Prototype.QueryLayer
{
    public abstract class EntityQueryManager : IDisposable
    {
        #region Constructor for ef db context 
        //private PrototypeDBContext _cnxt = null;

        //public PrototypeDBContext PrototypeDBContext
        //{
        //    get
        //    {
        //        if (_cnxt == null)
        //        {
        //            _cnxt = new PrototypeDBContext();
        //        }
        //        return _cnxt;
        //    }
        //}

        #endregion

        #region IDisposable Members

        private Boolean _disposed = false;

        protected void Dispose(Boolean disposing)
        {
            //if (!this._disposed)
            //{
            //    if (disposing)
            //    {
            //        if (_cnxt != null)
            //        {
            //            //_cnxt.Dispose();
            //            _cnxt = null;
            //        }
            //    }
            //}
            this._disposed = true;
        }
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(Boolean disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
