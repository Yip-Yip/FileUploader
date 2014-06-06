using Prototype.ModelMapper;
using System;

namespace Prototype.LogicLayer
{
    public class BaseLogicLayer : IDisposable
    {
        public readonly IMapper mapper;

        #region Constructors

        public BaseLogicLayer(IMapper mapper)
        {
            this.mapper = mapper;
        }

        #endregion

        #region IDisposable Members
        private Boolean _disposed = false;        // To detect redundant calls
        // IDisposable
        protected void Dispose(Boolean disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {

                }

                // TODO: free your own state (unmanaged objects).
                // TODO: set large fields to null.
            }
            this._disposed = true;
        }
        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(Boolean disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }

}
