using FoodShop.Application.Filters;
using FoodShop.Application.ProductEntries;
using FoodShop.Application.Queries;
using FoodShop.Application.VariationOptions;
using FoodShop.Application.VariationOptions.Commands.CreateVariationOption;
using FoodShop.Application.VariationOptions.Commands.DeleteVariationOption;
using FoodShop.Application.VariationOptions.Commands.UpdateVariationOption;
using FoodShop.Application.VariationOptions.Queries.GetVariationOptionById;
using FoodShop.Application.VariationOptions.Queries.GetVariationOptions;
using FoodShop.Application.Variations.Queries.GetVariations;
using FoodShop.Domain.Entities;
using FoodShop.Presentation.Paginations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FoodShop.Presentation.Endpoints;

public static class VariationOptionEndpoint
{

    public static RouteGroupBuilder MapVariationOptions(this IEndpointRouteBuilder route)
    {
        var group = route.MapGroup("/VariationOptions");
        
        group.WithTags("Variation Options");

        group.MapGet("/", async ([FromServices] ISender sender, 
            [AsParameters] PaginationFilter<VariationOption> paginationFilter
            ,LinkGenerator linkgen) =>
        {
            var result = await sender.Send(new GetVariationOptionsQuery(paginationFilter));

            if (result is PaginatedQueryResult<VariationOptionDto>)
                (result as PaginatedQueryResult<VariationOptionDto>).SetUrls(linkgen, "GetVariationOptions");

            return Results.Ok(result);
        }).WithName("GetVariationOptions");

        group.MapGet("/{id:guid}", async ([FromServices] ISender sender, [FromRoute] Guid id) =>
        {
            var result = await sender.Send(new GetVariationOptionByIdQuery(id));
            if (result == null)
                return Results.NotFound();
            return Results.Ok(result);
        }).WithName("GetVariationOptionById");

        group.MapPost("/", async ([FromServices] ISender sender, [FromBody] CreateVariationOptionCommand command) =>
        {
            var result = await sender.Send(command);
            return Results.CreatedAtRoute("GetVariationOptionById", new { id = result.Id });
        }).WithName("CreateVariationOption");

        group.MapPut("/{id:guid}",
            async (
                [FromServices] ISender sender,
                [FromBody] UpdateVariationOptionCommand command,
                [FromRoute] Guid id) =>
            {
                if (id != command.Id) return Results.BadRequest("Ids do not match!"); //TODO
                var result = await sender.Send(command);
                return Results.Ok(result);
            }).WithName("UpdateVariationOption");

        group.MapDelete("/{id:guid}",
            async (
                [FromServices] ISender sender,
                [FromRoute] Guid id) =>
            {
                await sender.Send(new DeleteVariationOptionCommand(id));
                return Results.Ok();
            }).WithName("DeleteVariationOption");

        return group;
    }
    
    
    
    
}
