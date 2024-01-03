
using FoodShop.Application.Filters;
using FoodShop.Application.ProductEntries;
using FoodShop.Application.Products;
using FoodShop.Application.Products.Commands.CreateProduct;
using FoodShop.Application.Products.Commands.DeleteProduct;
using FoodShop.Application.Products.Commands.DeleteProducts;
using FoodShop.Application.Products.Commands.UpdateProduct;
using FoodShop.Application.Products.Queries.GetProductById;
using FoodShop.Application.Products.Queries.GetProducts;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using FoodShop.Presentation.Paginations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;


namespace FoodShop.Presentation.Endpoints;

public static class ProductEndpoint
{

    public static RouteGroupBuilder MapProducts(this IEndpointRouteBuilder app)
    {

        var group = app.MapGroup("/products");
        

        group.WithTags("Products");

        group.MapGet("/", async (
            [FromServices] ISender sender,
            [AsParameters] PaginationFilter<Product> paginationFilter,
            [AsParameters] ProductFilter productFilter,
            LinkGenerator linkgen) =>
        {
            var result = await sender.Send(new GetProductsQuery(paginationFilter,productFilter));

            //temp
            if (result is PaginatedQueryResult<ProductDto>)
                (result as PaginatedQueryResult<ProductDto>).SetUrls(linkgen, "GetProducts");

            return Results.Ok(result);
        }).WithName("GetProducts");



        group.MapGet("/{id:guid}", async ([FromServices] ISender sender, [FromRoute] Guid id) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));
            if (result == null)
                return Results.NotFound();
            return Results.Ok(result);
        }).WithName("GetProductById");

        group.MapPost("/", async ([FromServices] ISender sender, [FromBody] CreateProductCommand command) =>
        {
            var result = await sender.Send(command);
            return Results.CreatedAtRoute("GetProductById", new { id = result.Id });
        }).WithName("CreateProduct");

        group.MapPut("/{id:guid}",
            async (
                [FromServices] ISender sender,
                [FromBody] UpdateProductCommand command,
                [FromRoute] Guid id) =>
            {
                if (id != command.Id) return Results.BadRequest("Ids do not match!"); //TODO
                var result = await sender.Send(command);
                return Results.Ok(result);
            }).WithName("UpdateProduct");

        group.MapDelete("/{id:guid}",
            async (
                [FromServices] ISender sender,
                [FromRoute] Guid id) =>
            {
                await sender.Send(new DeleteProductCommand(id));
                return Results.Ok();
            }).WithName("DeleteProduct");

        group.MapDelete("/",
            async (
                [FromServices] ISender sender,
                [FromBody] IEnumerable<Guid> ids) =>
            {
                await sender.Send(new DeleteProductsCommand(ids));
                return Results.Ok();
            }).WithName("DeleteProducts");

        return group;
    }
}