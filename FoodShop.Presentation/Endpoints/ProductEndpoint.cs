using Carter;
using FoodShop.Application.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace FoodShop.Presentation.Endpoints;

public class ProductEndpoint : CarterModule
{
    public ProductEndpoint()
    :base("/products") {   }
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", async (ISender sender) =>
        {
            var result = await sender.Send(new GetProductsQuery());
            return Results.Ok(result);
        });
    }
}