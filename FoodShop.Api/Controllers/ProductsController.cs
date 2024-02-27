using FoodShop.Application.Filters;
using FoodShop.Application.Products.Queries.GetProducts;
using FoodShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodShop.Application.Products.Queries.GetProductById;
using System.Reflection;
using FoodShop.Application.Products.Commands.CreateProduct;
using FoodShop.Application.Products.Commands.UpdateProduct;
using FoodShop.Application.Products.Commands.DeleteProduct;
using FoodShop.Application.Products.Commands.DeleteProducts;
using RESTFulSense.Controllers;
using FoodShop.Common.Endpoints;

namespace FoodShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : RESTFulController
    {
        public ISender _sender { get; }

        public ProductsController(ISender sender)
        {
            _sender = sender;
            
        }

        [HttpGet(ProductEndpoints.GetProductsEndpoint)]
        public async Task<IActionResult> GetProductsAsync(
            [FromQuery] PaginationFilter<Product> paginationFilter,
            [FromQuery] ProductFilter productFilter
            )
        {
            var result = await _sender.Send(new GetProductsQuery(paginationFilter, productFilter));

            return Ok(result);
        }

        [HttpGet(ProductEndpoints.GetProductByIdEndpoint)]
        public async Task<IActionResult> GetProductByIdAsync
            (
                [FromRoute] Guid Id
            )
        {
            var result = await _sender.Send(new GetProductByIdQuery(Id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostProductAsync(
            [FromBody] CreateProductCommand command
            )
        {
            var result = await _sender.Send(command);
            return CreatedAtAction(nameof(GetProductByIdAsync), new { result.Id },result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProductAsync
            (
            [FromBody] UpdateProductCommand command,
            [FromRoute] Guid id
            )
        {
            if (id != command.Id) return BadRequest("Ids do not match!"); //TODO
            var result = await _sender.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProductByIdAsync(
            [FromRoute] Guid id
            )
        {
            await _sender.Send(new DeleteProductCommand(id));
            return Ok();
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteProductsByIdsAsync(
            [FromBody] IEnumerable<Guid> ids
            )
        {
            await _sender.Send(new DeleteProductsCommand(ids));
            return Ok();
        }

    }
}
