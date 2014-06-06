using System;
using System.Collections.Generic;
using Prototype.EF.Models;

namespace MessageLog.EF.Models
{
    public partial class CustomerAddress
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public short AddressType { get; set; }
        public string UnitNumber { get; set; }
        public string BuildingName { get; set; }
        public string BuildingName2 { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }
        public string StreetDirection { get; set; }
        public string DependantLocality { get; set; }
        public string Locality { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public Nullable<DateTime> AtAddressSince { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
