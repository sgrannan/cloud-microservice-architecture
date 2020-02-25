using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomerService.Data.Interfaces;
using CustomerService.Data.Models;
using System.Threading;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(String customerId)
        {
            Customers customer = await _customerRepository.GetByIdAsync(customerId);

            var response = new CustomerResponse(customer);

            return new OkObjectResult(response);
        }
    }
}