using CustomerService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Data.Interfaces
{
    public interface ICustomerRepository : IAsyncRepository<Customers>
    {        
    }
}
