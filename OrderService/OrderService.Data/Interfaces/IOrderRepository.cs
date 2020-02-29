using OrderService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Data.Interfaces
{
    public interface IOrderRepository : IAsyncRepository<Orders>
    {
        Task<IList<Orders>> GetByCustomerIdAsync(string customerId);
    }
}
