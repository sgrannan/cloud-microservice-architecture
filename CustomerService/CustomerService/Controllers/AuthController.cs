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
    [Route("api/auth")]
    public class AuthController : BaseApiController
    {
        private UserRepository _userRepository;

        public AuthController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("/signin")]
        public async Task<IActionResult> SignIn(String username)
        {
            var user = await _userRepository.GetByUsername(username);

            return new OkObjectResult(new AuthResponse(user));
        }
    }
}