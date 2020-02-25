using CustomerService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Models.Response
{
    public class CustomerResponse
    {
        private String firstName;
        private String lastName;
        private Guid customerId;
        private List<Addresses> addresses;

        public CustomerResponse(Customers customer)
        {
            this.CustomerId = customer.CustomerId;
            this.FirstName = customer.FirstName;
            this.LastName = customer.LastName;
            this.Addresses = customer.Addresses.ToList();
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public Guid CustomerId { get => customerId; set => customerId = value; }
        public List<Addresses> Addresses { get => addresses; set => addresses = value; }
    }
}
