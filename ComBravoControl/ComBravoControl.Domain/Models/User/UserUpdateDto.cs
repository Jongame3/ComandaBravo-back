using ComBravo.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.Domains.Models.User
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string Email { get; set; }
        public string Contacts { get; set; }

    }
}
