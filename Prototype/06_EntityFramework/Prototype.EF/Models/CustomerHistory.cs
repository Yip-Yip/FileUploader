using System;
using System.Collections.Generic;
using Prototype.EF.Models;

namespace MessageLog.EF.Models
{
    public partial class CustomerHistory
    {
        public int CustomerId { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public string CustomerDetail { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
