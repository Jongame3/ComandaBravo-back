using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.Domains.Models.Base
{
    public class ResponseAction
    {
        public bool IsSucces { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
    }
}
