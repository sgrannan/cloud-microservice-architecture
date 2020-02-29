using CustomerService.Data.Interfaces;
using CustomerService.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customers>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext customerContext) : base(customerContext) { }

        public async Task<Customers> GetByIdAsync(string customerId)
        {
            Guid guid = new Guid(customerId.Trim());
            return await _dbContext.Customers.Include(a => a.Addresses).FirstOrDefaultAsync(c => c.CustomerId == guid);
        }
    }
}
