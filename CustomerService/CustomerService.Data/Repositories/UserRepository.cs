using CustomerService.Data.Interfaces;
using CustomerService.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Data.Repositories
{
    public class UserRepository : BaseRepository<Users>, IUserRepository
    {
        public UserRepository(CustomerContext customerContext) : base(customerContext) { }

        public Task<Users> GetByUsername(string username)
        {
            return _dbContext.Users.Include(u => u.Customer).FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
