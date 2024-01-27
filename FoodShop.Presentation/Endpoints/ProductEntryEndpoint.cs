using FoodShop.Application.Filters;
using FoodShop.Application.ProductEntries;
using FoodShop.Application.ProductEntries.Commands.CreateProductEntry;
using FoodShop.Application.ProductEntries.Commands.DeleteProductEntries;
using FoodShop.Application.ProductEntries.Commands.DeleteProductEntry;
using FoodShop.Application.ProductEntries.Commands.UpdateProductEntry;
using FoodShop.Application.ProductEntries.Queries.GetProductEntries;
using FoodShop.Application.ProductEntries.Queries.GetProductEntryById;
using FoodShop.Application.Products.Commands.CreateProduct;
using FoodShop.Application.Products.Commands.DeleteProduct;
using FoodShop.Application.Products.Commands.UpdateProduct;
using FoodShop.Application.Products.Queries.GetProductById;
using FoodShop.Application.Products.Queries.GetProducts;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using FoodShop.Presentation.Paginations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Reflection;

namespace FoodShop.Presentation.Endpoints;

public static class ProductEntryEndpoint
{
    public static RouteGroupBuilder MapProductEntries(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/ProductEntries");
        

        group.WithTags("ProductEntries");

        group.MapGet("/", async ([FromServices] ISender sender,
            [AsParameters] PaginationFilter<ProductEntry> paginationFilter,
            [AsParameters] ProductEntryFilter productEntryFilter,
            LinkGenerator linkgen) =>
        {
            var result = await sender.Send(new GetProductEntriesQuery(paginationFilter,productEntryFilter));
            
            //temp
            if(result is PaginatedQueryResult<ProductEntryDto>)
                (result as PaginatedQueryResult<ProductEntryDto>).SetUrls(linkgen, "GetProductEntries");

            return Results.Ok(result);
        }).WithName("GetProductEntries");

        group.MapGet("/{id:guid}", async ([FromServices] ISender sender, [FromRoute] Guid id) =>
        {
            var result = await sender.Send(new GetProductEntryByIdQuery(id));
            if (result == null)
                return Results.NotFound();
            return Results.Ok(result);
        }).WithName("GetProductEntryById");

        group.MapPost("/", async ([FromServices] ISender sender, [FromBody] CreateProductEntryCommand command) =>
        {
            var result = await sender.Send(command);
            return Results.CreatedAtRoute("GetProductEntryById", new { id = result.Id });
        }).WithName("CreateProductEntry");

        group.MapPut("/{id:guid}",
            async (
                [FromServices] ISender sender,
                [FromBody] UpdateProductEntryCommand command,
                [FromRoute] Guid id) =>
            {
                if (id != command.Id) return Results.BadRequest("Ids do not match!"); //TODO
                var result = await sender.Send(command);
                return Results.Ok(result);
            }).WithName("UpdateProductEntry");

        group.MapDelete("/", async ([FromServices] ISender sender,
            [FromBody] IEnumerable<Guid> ids) =>
        {
            await sender.Send(new DeleteProductEntriesCommand(ids));
            return Results.Ok();
        }).WithName("DeleteProductEntries");

        group.MapDelete("/{id:guid}",
            async (
                [FromServices] ISender sender,
                [FromRoute] Guid id) =>
            {
                await sender.Send(new DeleteProductEntryCommand(id));
                return Results.Ok();
            }).WithName("DeleteProductEntry");
        
        return group;
    }
    
}