using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravoControl.Domains.Entities.User
{
    public class UserData
    {
        public int Id { get; set; }
        
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Contacts { get; set; }

        public DateTime DOB { get; set; }

    }
}
