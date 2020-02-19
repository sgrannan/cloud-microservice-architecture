using CustomerService.Data.Interfaces;
using CustomerService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customers>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext customerContext) : base(customerContext) { }
    }
}
