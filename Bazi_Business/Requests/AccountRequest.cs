﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazi_Business.Requests
{
    public class LogInRequest : BaseRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterRequest : BaseRequest
    {
        
    }
}