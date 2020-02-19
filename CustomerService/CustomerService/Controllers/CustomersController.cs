using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    public class CustomersController : BaseApiController
    {
        [Route("/{customerId}")]
        [HttpGet]
        public async Task<IActionResult> GetCustomer(int CustomerId)
        {
            var response = new CustomerResponse();

            return new OkObjectResult(response);
        }
    }
}