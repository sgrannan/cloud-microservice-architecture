using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Data.Interfaces;
using CustomerService.Models.Request;
using CustomerService.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> SignIn([FromBody] AuthRequest loginRequest)
        {
            var user = await _userRepository.GetByUsername(loginRequest.Username);

            return new OkObjectResult(new AuthResponse(user));
        }
    }
}