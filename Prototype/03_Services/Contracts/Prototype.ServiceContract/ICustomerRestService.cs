using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Prototype.Common;
using Prototype.MessageObjectLibrary;

namespace Prototype.RestService
{
    [ServiceContract]
    public interface ICustomerRestService
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetCustomer/", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CustomerDto GetCustomer();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetCustomerList/")]
        List<CustomerDto> GetCustomerList();

        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetCustomerRequest/")]
        //CustomerRequest GetCustomerRequest(int id);

        //[OperationContract]
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "AddAttachedFileAsBytes/")]
        int AddAttachedFileAsBytes(int RequestId, Enumumerations.AttachmentType FileType, string ContentType, string OriginalFileName, Byte[] Content);
        
    }
}
//RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json