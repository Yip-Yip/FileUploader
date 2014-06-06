using System;
using System.Collections.Generic;

namespace Prototype.ModelMapper
{
    public interface IMapper
    {
        #region Public Methods and Operators

        TDest Map<TSrc, TDest>(TSrc source);

        TDest Map<TSrc, TDest>(TSrc source, TDest destination);

        object Map(object source, Type sourceType, Type destinationType);

        void Map(object source, object destination, Type sourceType, Type destinationType);

        void Map<TSrc, TDest>(IList<TSrc> source, IList<TDest> destination);

        #endregion
    }
}
