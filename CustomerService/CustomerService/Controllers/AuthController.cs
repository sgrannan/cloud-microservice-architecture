using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Data.Repositories;
using CustomerService.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private UserRepository _userRepository;

        public AuthController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("/signin")]
        public async Task<IActionResult> SignIn(String username)
        {
            var user = await _userRepository.GetByUsername(username);

            return new OkObjectResult(new AuthResponse(user));
        }
    }
}