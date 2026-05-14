using ComBravo.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.Domains.Models.User
{
    public class UserRegistrationDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Contacts { get; set; }
    }
}
