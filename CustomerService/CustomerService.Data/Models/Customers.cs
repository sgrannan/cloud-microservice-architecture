using System;
using System.Collections.Generic;

namespace CustomerService.Data.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Addresses = new HashSet<Addresses>();
            Users = new HashSet<Users>();
        }

        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
