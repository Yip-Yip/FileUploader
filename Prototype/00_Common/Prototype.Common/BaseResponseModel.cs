using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Common
{
    public class BaseResponseModel
    {
        public BaseResponseModel()
        {
        }

        public BaseResponseModel(bool success, string serviceResponseMessage, HttpStatusCode? httpStatusCode)
        {
            Success = success;
            ServiceResponseMessage = serviceResponseMessage;
            HttpStatusCode = httpStatusCode;
        }

        public bool Success { get; set; }
        public string ServiceResponseMessage { get; set; }
        public HttpStatusCode? HttpStatusCode { get; set; }
    }
}
