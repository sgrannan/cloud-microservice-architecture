using InventoryService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Data.Interfaces
{
    public interface IItemRepository : IAsyncRepository<Items>
    {
        Task<Items> GetByIdAsync(string itemId);
    }
}
