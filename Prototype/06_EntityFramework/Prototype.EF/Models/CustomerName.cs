using System;
using System.Collections.Generic;
using Prototype.EF.Models;

namespace MessageLog.EF.Models
{
    public partial class CustomerName
    {
        public int CustomerNameId { get; set; }
        public bool IsPrimaryName { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
