using FoodShop.Application.Filters;
using FoodShop.Application.ProductEntries;
using FoodShop.Application.Products.Commands.CreateProduct;
using FoodShop.Application.Products.Commands.DeleteProduct;
using FoodShop.Application.Products.Commands.UpdateProduct;
using FoodShop.Application.Products.Queries.GetProductById;
using FoodShop.Application.Products.Queries.GetProducts;
using FoodShop.Application.Queries;
using FoodShop.Application.Variations;
using FoodShop.Application.Variations.Commands.CreateVariation;
using FoodShop.Application.Variations.Commands.DeleteVariation;
using FoodShop.Application.Variations.Commands.UpdateVariation;
using FoodShop.Application.Variations.Queries.GetVariationById;
using FoodShop.Application.Variations.Queries.GetVariations;
using FoodShop.Domain.Entities;
using FoodShop.Presentation.Paginations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FoodShop.Presentation.Endpoints;

public static class VariationEndpoint
{
    public static RouteGroupBuilder MapVariations(this IEndpointRouteBuilder app)
    {

        var group = app.MapGroup("/variations");
        

        group.WithTags("Variations");

        group.MapGet("/", async ([FromServices] ISender sender, 
            [AsParameters] PaginationFilter<Variation> paginationFilter,
            LinkGenerator linkgen) =>
        {
            var result = await sender.Send(new GetVariationsQuery(paginationFilter));

            if (result is PaginatedQueryResult<VariationDto>)
                (result as PaginatedQueryResult<VariationDto>).SetUrls(linkgen, "GetVariations");

            return Results.Ok(result);
        }).WithName("GetVariations");

        group.MapGet("/{id:guid}", async ([FromServices] ISender sender, [FromRoute] Guid id) =>
        {
            var result = await sender.Send(new GetVariationByIdQuery(id));
            if (result == null)
                return Results.NotFound();
            return Results.Ok(result);
        }).WithName("GetVariationById");

        group.MapPost("/", async ([FromServices] ISender sender, [FromBody] CreateVariationCommand command) =>
        {
            var result = await sender.Send(command);
            return Results.CreatedAtRoute("GetVariationById", new { id = result.Id });
        }).WithName("CreateVariation");

        group.MapPut("/{id:guid}",
            async (
                [FromServices] ISender sender,
                [FromBody] UpdateVariationCommand command,
                [FromRoute] Guid id) =>
            {
                if (id != command.Id) return Results.BadRequest("Ids do not match!"); //TODO
                var result = await sender.Send(command);
                return Results.Ok(result);
            }).WithName("UpdateVariation");

        group.MapDelete("/{id:guid}",
            async (
                [FromServices] ISender sender,
                [FromRoute] Guid id) =>
            {
                await sender.Send(new DeleteVariationCommand(id));
                return Results.Ok();
            }).WithName("DeleteVariation");
        
        return group;
    }
}