using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class LoginStatus
    {
        public int status { get; set; }
        public string token { get; set; }

        public int customer_id { get; set; }

    }
}