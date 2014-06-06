using System.Collections.Generic;
using Prototype.Common;
using Prototype.LogicLayer;
// remove when DI is ready
using Prototype.MessageObjectLibrary;
using Prototype.ModelMapper;

namespace Prototype.RestService
{
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerRestService.svc or CustomerRestService.svc.cs at the Solution Explorer and start debugging.
    public class CustomerRestService : ICustomerRestService
    {
        private static readonly IMapper _mapper = new AutoMapperModelMapper();
        private ICustomerRestService _customer = new CustomerLL(_mapper);

        public CustomerRestService()
        {
        }

        public CustomerRestService(ICustomerRestService service)
        {
            _customer = service;
        }

        public CustomerDto GetCustomer()
        {
            return _customer.GetCustomer();
        }

        public List<CustomerDto> GetCustomerList()
        {
            return _customer.GetCustomerList();
        }

        public int AddAttachedFileAsBytes(int RequestId, Enumumerations.AttachmentType FileType, string ContentType, string OriginalFileName, byte[] Content)
        {
            throw new System.NotImplementedException();
        }
    }
}
