using FoodShop.Application.Categories.Queries.GetCategories;
using FoodShop.Application.Categories;
using FoodShop.Application.Filters;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.Identity.Client;
using FoodShop.Application.Categories.Queries.GetParentCategories;
using FoodShop.Application.Categories.Queries.GetCategoryById;
using FoodShop.Application.Categories.Commands.CreateCategory;
using FoodShop.Application.Categories.Commands.UpdateCategory;
using FoodShop.Application.Categories.Commands.DeleteCategory;
using FoodShop.Application.Categories.Commands.DeleteCategories;
using FoodShop.Application.Categories.Commands.RemoveVariation;
using FoodShop.Application.Categories.Queries.GetVariations;
using FoodShop.Application.Categories.Commands.AddVariation;

namespace FoodShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ISender _sender { get; }
        public CategoriesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories
            (
                [FromQuery] CategoryFilter categoryFilter,
                [FromQuery] PaginationFilter<Category> PaginationFilter
            )
        {
            var query = new GetCategoriesQuery(categoryFilter, PaginationFilter);
            var result = await _sender.Send(query);

            return Ok(result);
        }

        [HttpGet("parent")]
        public async Task<IActionResult> GetParentCategories()
        {
            var result = await _sender.Send(new GetParentCategoriesQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCategoryByIdAsync
            (
                [FromRoute] Guid Id
            )
        {
            var result = await _sender.Send(new GetCategoryByIdQuery(Id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategoryAsync
            (
                [FromBody] CreateCategoryCommand command
            )
        {
            var result = await _sender.Send(command);
            return CreatedAtAction(nameof(GetCategoryByIdAsync), new { id = result.Id });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategoryAsync
            (
                [FromBody] UpdateCategoryCommand command,
                [FromRoute] Guid id
            )
        {
            if (id != command.Id) return BadRequest("Ids do not match!"); //TODO
            var result = await _sender.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategoryAsync
            (
                [FromRoute] Guid Id
            )
        {
            await _sender.Send(new DeleteCategoryCommand(Id));
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoriesAsync
            (
                [FromBody] IEnumerable<Guid> ids
            )
        {
            await _sender.Send(new DeleteCategoriesCommand(ids));
            return Ok();
        }

        [HttpDelete("{categoryId:guid}/variations/{variationId:guid}")]
        public async Task<IActionResult> DeleteVariationFromCategoryAsync
            (
                [FromRoute] Guid categoryId,
                [FromRoute] Guid variationId
            )
        {
            await _sender.Send(new RemoveVariationCommand(categoryId, variationId));
            return Ok();
        }

        [HttpGet("{id:guid}/variations")]
        public async Task<IActionResult> GetVariations
            (
                [FromRoute] Guid Id
            )
        {
            var result = await _sender.Send(new GetVariationsQuery(Id));
            return Ok(result);
        }

        [HttpPost("{categoryId:guid}/variations/{variationId:guid}")]
        public async Task<IActionResult> AddVariationToCategoryAsync
            (
                [FromRoute] Guid categoryId,
                [FromRoute] Guid variationId
            )
        {
            await _sender.Send(new CategoryAddVariationCommand(categoryId, variationId));
            return Ok();
        }

    }

}
