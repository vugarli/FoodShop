﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Abstractions.Services
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
