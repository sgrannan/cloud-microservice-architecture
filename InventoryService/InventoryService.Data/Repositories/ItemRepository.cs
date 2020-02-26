using InventoryService.Data.Interfaces;
using InventoryService.Data.Models;
using InventoryService.Data;
using InventoryService.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Data.Repositories
{
    public class ItemRepository : BaseRepository<Items>, IItemRepository
    {
        public ItemRepository(InventoryContext customerContext) : base(customerContext) { }

        public async Task<Items> GetByIdAsync(string itemId)
        {
            Guid guid = new Guid(itemId.Trim());
            return await _dbContext.Items.Include(i => i.CategoryType).FirstOrDefaultAsync(c => c.ItemId == guid);
        }

        public override async Task<IReadOnlyList<Items>> ListAllAsync()
        {
            return await _dbContext.Items.Include(i => i.CategoryType).ToListAsync();
        }
    }
}
