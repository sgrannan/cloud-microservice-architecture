using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Models.Request
{
    public class AuthRequest
    {
        [Required]
        private String _username;
        
        [Required]
        private String _password;

        public string Username { get => _username; set => _username = value; }

        public string Password { get => _password; set => _password = value; }
    }
}
