using System;
using System.Runtime.Serialization;

namespace Prototype.MessageObjectLibrary
{
    [DataContract]
    public class CustomerDto
    {
        public CustomerDto()
        {
            //this.CustomerAddresses = new List<CustomerAddress>();
            //this.CustomerHistories = new List<CustomerHistory>();
            //this.CustomerNames = new List<CustomerName>();
            //this.CustomerDriverLicences = new List<CustomerDriverLicence>();
            //this.Requests = new List<Request>();
        }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public Nullable<DateTime> DateOfBirth { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public string HomePhone { get; set; }

        [DataMember]
        public string WorkPhone { get; set; }

        [DataMember]
        public string MobilePhone { get; set; }

        [DataMember]
        public string Employer { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public Nullable<int> ConsumerId { get; set; }

        [DataMember]
        public Nullable<short> LastDeliveryType { get; set; }

        [DataMember]
        public Nullable<DateTime> LastPOICheckDate { get; set; }

        [DataMember]
        public DateTime CreatedOn { get; set; }

        [DataMember]
        public DateTime ModifiedOn { get; set; }

        [DataMember]
        public bool RegisteredPreCYC { get; set; }

        [DataMember]
        public string IdentityCheckStatus { get; set; }

        [DataMember]
        public Nullable<short> CCBmatch { get; set; }

        [DataMember]
        public Nullable<short> IdentiCheck { get; set; }

        //public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        //public virtual ICollection<CustomerHistory> CustomerHistories { get; set; }
        //public virtual ICollection<CustomerName> CustomerNames { get; set; }
        //public virtual ICollection<CustomerDriverLicence> CustomerDriverLicences { get; set; }
        //public virtual ICollection<Request> Requests { get; set; }
    }
}
