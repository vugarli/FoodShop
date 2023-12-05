using Carter;
using FoodShop.Application.Products.Commands.CreateProduct;
using FoodShop.Application.Products.Queries.GetProductById;
using FoodShop.Application.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FoodShop.Presentation.Endpoints;

public class ProductEndpoint : CarterModule
{
    public ProductEndpoint()
    :base("/products") {   }
    
    
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", async ([FromServices]ISender sender) =>
        {
            var result = await sender.Send(new GetProductsQuery());
            return Results.Ok(result);
        });

        app.MapGet("/{id:guid}", async ([FromServices] ISender sender,[FromRoute] Guid id) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));
            return Results.Ok(result);
        }).WithName("GetProductById");

        app.MapPost("/", async ([FromServices] ISender sender, [FromBody] CreateProductCommand command) =>
        {
            var result = await sender.Send(command);
            return Results.CreatedAtRoute("GetProductById",new{ id = result });
        });

    }
}