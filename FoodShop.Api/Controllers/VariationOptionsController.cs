using FoodShop.Application.Filters;
using FoodShop.Application.VariationOptions.Queries.GetVariationOptions;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using FoodShop.Application.VariationOptions.Queries.GetVariationOptionById;
using FoodShop.Application.VariationOptions.Commands.CreateVariationOption;
using FoodShop.Application.VariationOptions.Commands.UpdateVariationOption;
using FoodShop.Application.VariationOptions.Commands.DeleteVariationOption;
using FoodShop.Domain.Entities;

namespace FoodShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariationOptionsController : ControllerBase
    {
        private ISender _sender { get; }
        public VariationOptionsController(ISender sender)
        {
            _sender = sender;
        }


        [HttpGet]
        public async Task<IActionResult> GetVariationOptionsAsync
            (
            [FromQuery] PaginationFilter<VariationOption> paginationFilter
            )
        {
            var result = await _sender.Send(new GetVariationOptionsQuery(paginationFilter));

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetVariaitonOptionByIdAsync
        (
        [FromRoute] Guid Id
            )
        {
            var result = await _sender.Send(new GetVariationOptionByIdQuery(Id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostVariationOptionAsync
        (
            [FromBody] CreateVariationOptionCommand command
        )
        {
            var result = await _sender.Send(command);
            return CreatedAtAction(nameof(GetVariaitonOptionByIdAsync), 
                new { id = result.Id });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateVariationOptionAsync
            (
                [FromBody] UpdateVariationOptionCommand command,
                [FromRoute] Guid Id
            )
        {
            if (Id != command.Id) return BadRequest("Ids do not match!"); //TODO
            var result = await _sender.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteVariationOptionAsync
            (
                [FromRoute] Guid Id
            )
        {
            await _sender.Send(new DeleteVariationOptionCommand(Id));
            return Ok();
        }

    }
}
