﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity;

namespace FoodShop.Infrastructure.IdentityRelated
{
    public class ApplicationIdentityUser : IdentityUser<Guid> { } 
}
