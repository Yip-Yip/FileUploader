using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageLog.EF.Models;

namespace Prototype.EF.Models
{
    public partial class Customer
    {
        
        public Customer()
        {
            this.CustomerAddresses = new List<CustomerAddress>();
            this.CustomerHistories = new List<CustomerHistory>();
            this.CustomerNames = new List<CustomerName>();
            this.CustomerDriverLicences = new List<CustomerDriverLicence>();
            this.Requests = new List<Request>();
        }

        public int CustomerId { get; set; }
        public string CountryCode { get; set; }
        public string Title { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Employer { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<int> ConsumerId { get; set; }
        public Nullable<short> LastDeliveryType { get; set; }
        public Nullable<System.DateTime> LastPOICheckDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool RegisteredPreCYC { get; set; }
        public string IdentityCheckStatus { get; set; }
        public Nullable<short> CCBmatch { get; set; }
        public Nullable<short> IdentiCheck { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public virtual ICollection<CustomerHistory> CustomerHistories { get; set; }
        public virtual ICollection<CustomerName> CustomerNames { get; set; }
        public virtual ICollection<CustomerDriverLicence> CustomerDriverLicences { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
