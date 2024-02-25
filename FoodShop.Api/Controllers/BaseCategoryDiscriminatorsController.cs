using FoodShop.Application.BaseCategoryDiscriminators.Queries.GetBaseCategoryDiscriminators;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCategoryDiscriminatorsController : ControllerBase
    {
        private ISender _sender { get; }
        public BaseCategoryDiscriminatorsController
            (
                ISender sender
            )
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _sender.Send(new GetBaseCategoryDiscriminatorsQuery());
            return Ok(result);
        }

    }
}
