using System;
using System.Collections.Generic;

namespace CustomerService.Data.Models
{
    public partial class Addresses
    {
        public long AddressId { get; set; }
        public byte? AddressType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Zipcode { get; set; }
        public Guid CustomerId { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
