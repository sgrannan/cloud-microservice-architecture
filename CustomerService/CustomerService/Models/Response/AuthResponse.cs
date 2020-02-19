using CustomerService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Models.Response
{
    public class AuthResponse
    {
        private String username;
        private String customerName;
        private Guid customerId;
        private Task<Users> user;

        public AuthResponse(Users user)
        {
            this.username = user.Username;
            this.customerName = user.Customer.FirstName + " " + user.Customer.LastName;
            this.customerId = user.CustomerId;
        }

        public string Username { get => username; set => username = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public Guid CustomerId { get => customerId; set => customerId = value; }
    }
}
