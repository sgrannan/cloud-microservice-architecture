using OrderService.Data.Interfaces;
using OrderService.Data.Models;
using OrderService.Data;
using OrderService.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Data.Repositories
{
    public class OrderRepository : BaseRepository<Orders>, IOrderRepository
    {
        public OrderRepository(OrdersContext orderContext) : base(orderContext) { }

        public async Task<IList<Orders>> GetByCustomerIdAsync(string customerId)
        {
            Guid guid = new Guid(customerId.Trim());
            return await _dbContext.Orders.Include(o => o.OrderDetails).Where(c => c.CustomerId == guid).ToListAsync();
        }

        public override async Task<IReadOnlyList<Orders>> ListAllAsync()
        {
            return await _dbContext.Orders.Include(i => i.OrderDetails).ToListAsync();
        }
    }
}
