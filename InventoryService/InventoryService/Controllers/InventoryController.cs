using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Data.Interfaces;
using InventoryService.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public InventoryController(IItemRepository itemRespository)
        {
            _itemRepository = itemRespository;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            IReadOnlyList<Items> items = await _itemRepository.ListAllAsync();

            return new OkObjectResult(items);
        }

        [HttpGet("{itemId}")]
        public async Task<IActionResult> GetByItemId(String itemId)
        {
            Items item = await _itemRepository.GetByIdAsync(itemId);

            return new OkObjectResult(item);
        }
    }
}