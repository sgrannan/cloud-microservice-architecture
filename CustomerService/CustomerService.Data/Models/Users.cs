using System;
using System.Collections.Generic;

namespace CustomerService.Data.Models
{
    public partial class Users
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid CustomerId { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
