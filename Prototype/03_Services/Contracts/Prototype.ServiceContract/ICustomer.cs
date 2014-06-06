using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using Prototype.MessageObjectLibrary;

namespace Prototype.ServiceContract
{
    [ServiceContract]
    //[ValidationBehavior]
    public interface ICustomer
    {
        [OperationContract]
        CustomerDto GetCustomer(int id);

        [OperationContract]
        IEnumerable<CustomerDto> GetCustomerList();

        [OperationContract]
        CustomerDto UpdateCustomer(CustomerDto customer);


    }
}
