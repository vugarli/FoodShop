using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Abstractions.Services
{
    public interface IUserService
    {
        public Task CreateUserAsync(CreateUserRequest request);
    }
}
