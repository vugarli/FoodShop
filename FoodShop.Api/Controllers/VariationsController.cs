using FoodShop.Application.Filters;
using FoodShop.Application.Queries;
using FoodShop.Application.Variations;
using FoodShop.Application.Variations.Commands.CreateVariation;
using FoodShop.Application.Variations.Commands.DeleteVariation;
using FoodShop.Application.Variations.Commands.DeleteVariations;
using FoodShop.Application.Variations.Commands.UpdateVariation;
using FoodShop.Application.Variations.Queries.GetVariationById;
using FoodShop.Application.Variations.Queries.GetVariations;
using FoodShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Reflection;

namespace FoodShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariationsController : ControllerBase
    {
        public ISender _sender { get; }
        public VariationsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetVariationsAsync
        (
        [FromQuery] PaginationFilter<Variation> paginationFilter
            )
        {
            var result = await _sender.Send(new GetVariationsQuery(paginationFilter));

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetVariationByIdAsync
            (
            [FromRoute] Guid Id
            )
        {
            var result = await _sender.Send(new GetVariationByIdQuery(Id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostVariationAsync
            (
            [FromBody] CreateVariationCommand command
            )
        {
            var result = await _sender.Send(command);
            return CreatedAtAction(nameof(GetVariationByIdAsync), new { id = result.Id });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateVariationAsync
            (
            [FromBody] UpdateVariationCommand command,
            [FromRoute] Guid id
            )
        {
            if (id != command.Id) return BadRequest("Ids do not match!"); //TODO
            var result = await _sender.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteVariationByIdAsync
            (
            [FromRoute] Guid Id
            )
        {
            await _sender.Send(new DeleteVariationCommand(Id));
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVariationsByIdsAsync
            (
            [FromBody] IEnumerable<Guid> ids
            )
        {
            await _sender.Send(new DeleteVariationsCommand(ids));
            return Ok();
        }

    }
}
