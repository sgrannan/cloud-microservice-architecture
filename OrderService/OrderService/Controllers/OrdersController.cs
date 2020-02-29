using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Data.Interfaces;
using OrderService.Data.Models;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerOrders(String customerId)
        {
            IList<Orders> orders = await _orderRepository.GetByCustomerIdAsync(customerId);

            return new OkObjectResult(orders);
        }
    }
}