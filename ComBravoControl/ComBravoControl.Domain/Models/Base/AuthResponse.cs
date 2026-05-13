using ComBravo.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.Domains.Models.Base
{
    public class AuthResponse
    {
        public bool IsSucces { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
        public string Username {  get; set; }
        public UserRole Role { get; set; }
    }
}
