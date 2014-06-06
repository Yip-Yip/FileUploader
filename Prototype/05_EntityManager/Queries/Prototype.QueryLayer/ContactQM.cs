using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageLog.EF.Models;
using Prototype.EF.Models;

namespace Prototype.QueryLayer
{
    public class ContactQM : EntityQueryManager
    {
        #region public methods

        public Request GetRequest(int id)
        {
            // hardcoded for demo purposes
            return GetHardCodedRequest();

            // EF qry
            //using (var db = new PrototypeDBContext())
            //{
            //    var request = db.Requests.FirstOrDefault(r => r.RequestId == id);

            //    if (request != null)
            //    {
            //        return request;
            //    }
            //    return null;
            //}
        }

        public Customer GetCustomer(int id)
        {
            return GetHardCodedCustomer();
        }

        private Customer GetHardCodedCustomer()
        {
            var srcCustomer = new Customer()
            {
                CustomerId = 1234566,
                CountryCode = "AU",
                DateOfBirth = DateTime.Now,
                MobilePhone = "0147852369",
                EmailAddress = "stephenboulter@outlook.com",
                IdentityCheckStatus = "Approved"
            };
            return srcCustomer;
        }

        #endregion

        #region Private Methods

        private Request GetHardCodedRequest()
        {
            var srcRequest = new Request()
            {
                RequestId = 6830,
                CustomerId = 789,
                CustomerReference = "ABCD201405071029",
                RequestServiceType = "FastTrackOrder",
                CreatedOn = DateTime.Now,
                DueOn = DateTime.Now,
                RequestStatus = 100
            };

            return srcRequest;
        }

        #endregion
    }
}
