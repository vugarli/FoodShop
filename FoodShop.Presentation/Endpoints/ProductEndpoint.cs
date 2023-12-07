
using FoodShop.Application.Products.Commands.CreateProduct;
using FoodShop.Application.Products.Commands.DeleteProduct;
using FoodShop.Application.Products.Commands.UpdateProduct;
using FoodShop.Application.Products.Queries.GetProductById;
using FoodShop.Application.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;


namespace FoodShop.Presentation.Endpoints;

public static class ProductEndpoint
{

    public static RouteGroupBuilder MapProducts(this IEndpointRouteBuilder app)
    {

        var group = app.MapGroup("/products");
        

        group.WithTags("Products");

        group.MapGet("/", async ([FromServices] ISender sender) =>
        {
            var result = await sender.Send(new GetProductsQuery());
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
            return Results.CreatedAtRoute("GetProductById", new { id = result });
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
        
        return group;
    }
}