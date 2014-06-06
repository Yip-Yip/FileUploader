using System;
using System.Collections.Generic;
using System.Reflection;
using MessageLog.EF.Models;
using Prototype.Common;
using Prototype.EF.Models;
using Prototype.MessageObjectLibrary;
using Prototype.ModelMapper;
using Prototype.QueryLayer;
using Prototype.RestService;

namespace Prototype.LogicLayer
{
    public class CustomerLL : BaseLogicLayer, ICustomerRestService
    {

        private static int _MaxUploadFileSize = 1048576;
        private static string _AllowedUploadMIMETypes = "|application/pdf|image/jpeg|image/pjpeg|image/tiff|image/gif|image/png|";

        #region Constructors

        public CustomerLL(IMapper mapper)
            : base(mapper)
        {
        }

        #endregion

        #region Public Methods

        public CustomerRequest GetCustomerRequest(int id)
        {
            using (var contactQM = new ContactQM())
            {
                //get data from qry layer & return mapped dto object
                var srcRequest = contactQM.GetRequest(id);
                return mapper.Map<Request, CustomerRequest>(srcRequest);
            }
        }

        //public CustomerDto GetCustomer(int id)
        public CustomerDto GetCustomer()
        {
            using (var contactQM = new ContactQM())
            {
                var srcRequest = contactQM.GetCustomer(0);
                return mapper.Map<Customer, CustomerDto>(srcRequest);
            }
        }

        public List<CustomerDto> GetCustomerList()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods

        #endregion

        public int AddAttachedFileAsBytes(int requestId, Enumumerations.AttachmentType fileType, string contentType, string originalFileName, byte[] content)
        {
            int fileId = 0;

            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            if (content.Length > _MaxUploadFileSize)
            {
                throw new ArgumentException("File content is too long", "content");
            }

            if (string.IsNullOrEmpty(contentType))
            {
                throw new ArgumentNullException("contentType");
            }

            if (_AllowedUploadMIMETypes.IndexOf("|" + contentType.ToLower() + "|") < 0)
            {
                throw new ArgumentException("Invalid contentType", "contentType");
            }

            try
            {
                fileId = 999;
                //save to db here through entity framework
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fileId;
        }



    }
}
