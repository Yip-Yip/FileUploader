using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Common
{
    public class DtoResponseModel<TModel> : BaseResponseModel
    {
        public int UniqueId { get; set; }
        public TModel Model { get; set; }
    }
}
