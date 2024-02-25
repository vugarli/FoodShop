using FoodShop.Application.Filters;
using FoodShop.Application.ProductEntries.Queries.GetProductEntries;
using FoodShop.Application.ProductEntries;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using FoodShop.Application.ProductEntries.Queries.GetProductEntryById;
using FoodShop.Application.ProductEntries.Commands.CreateProductEntry;
using System.Collections.Specialized;
using FoodShop.Application.ProductEntries.Commands.UpdateProductEntry;
using FoodShop.Application.ProductEntries.Commands.DeleteProductEntries;
using FoodShop.Application.ProductEntries.Commands.DeleteProductEntry;

namespace FoodShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductEntriesController : ControllerBase
    {
        private ISender _sender { get; }
        public ProductEntriesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet()]
        public async Task<IActionResult> GetProductEntriesAsync
        (
        [FromQuery] PaginationFilter<ProductEntry> paginationFilter,
            [FromQuery] ProductEntryFilter productEntryFilter
            )
        {
            var result = await _sender.Send(new GetProductEntriesQuery(paginationFilter, productEntryFilter));

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductEntryByIdAsync
            (
            [FromRoute] Guid Id
            )
        {
            var result = await _sender.Send(new GetProductEntryByIdQuery(Id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> PostProductEntryAsync
            (
            [FromBody] CreateProductEntryCommand command
            )
        {
            var result = await _sender.Send(command);
            return CreatedAtAction(nameof(GetProductEntryByIdAsync), new { id = result.Id });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProductEntryAsync
            (
            [FromBody] UpdateProductEntryCommand command,
            [FromRoute] Guid id
            )
        {
            if (id != command.Id) return BadRequest("Ids do not match!"); //TODO
            var result = await _sender.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProductEntryByIdAsync
            (
            [FromRoute] Guid id
            )
        {
            await _sender.Send(new DeleteProductEntryCommand(id));
            return Ok();
        }


        [HttpDelete()]
        public async Task<IActionResult> DeleteProductEntriesAsync
            (
            [FromBody] IEnumerable<Guid> ids
            )
        {
            await _sender.Send(new DeleteProductEntriesCommand(ids));
            return Ok();
        }
        


    }
}
