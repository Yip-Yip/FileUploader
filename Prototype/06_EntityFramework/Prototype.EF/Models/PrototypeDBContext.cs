using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageLog.EF.Models;

namespace Prototype.EF.Models
{
    public partial class PrototypeDBContext : DbContext
    {
        static PrototypeDBContext()
        {
            Database.SetInitializer<PrototypeDBContext>(null);
        }

        public CCB_D2CContext()
            : base("Name=PrototypeDBContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerDriverLicence> CustomerDriverLicences { get; set; }
        public DbSet<CustomerHistory> CustomerHistories { get; set; }
        public DbSet<CustomerName> CustomerNames { get; set; }
    }
}
