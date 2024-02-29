using FoodShop.Application.Abstractions.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IUserService _userService { get; }
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("registercustomer")]
        public async Task<IActionResult> RegisterAsync()
        {
            await _userService.CreateUserAsync(new() { });
            return Ok();
        }

    }
}
