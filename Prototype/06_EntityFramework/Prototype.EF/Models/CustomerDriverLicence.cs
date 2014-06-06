using System;
using System.Collections.Generic;
using Prototype.EF.Models;

namespace MessageLog.EF.Models
{
    public partial class CustomerDriverLicence
    {
        public int DriverLicenceId { get; set; }
        public int CustomerId { get; set; }
        public string Number { get; set; }
        public string Version { get; set; }
        public string LocationIssued { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
