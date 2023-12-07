using FoodShop.Application.Categories.Commands.CreateCategory;
using FoodShop.Application.Categories.Commands.DeleteCategory;
using FoodShop.Application.Categories.Commands.UpdateCategory;
using FoodShop.Application.Categories.Queries.GetCategories;
using FoodShop.Application.Categories.Queries.GetCategoryById;
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

public static class CategoryEndpoint
{


    public static RouteGroupBuilder MapCategories (this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/categories");
        group.WithTags("Categories");
        
        

        group.MapGet("/", async ([FromServices] ISender sender) =>
        {
            var result = await sender.Send(new GetCategoriesQuery());
            return Results.Ok(result);
        }).WithName("GetCategories");

        group.MapGet("/{id:guid}", async ([FromServices] ISender sender, [FromRoute] Guid id) =>
        {
            var result = await sender.Send(new GetCategoryByIdQuery(id));
            if (result == null)
                return Results.NotFound();
            return Results.Ok(result);
        }).WithName("GetCategoryById");

        group.MapPost("/", async ([FromServices] ISender sender, [FromBody] CreateCategoryCommand command) =>
        {
            var result = await sender.Send(command);
            return Results.CreatedAtRoute("GetCategoryById", new { id = result.Id });
        }).WithName("CreateCategory");

        group.MapPut("/{id:guid}",
            async (
                [FromServices] ISender sender,
                [FromBody] UpdateCategoryCommand command,
                [FromRoute] Guid id) =>
            {
                if (id != command.Id) return Results.BadRequest("Ids do not match!"); //TODO
                var result = await sender.Send(command);
                return Results.Ok(result);
            }).WithName("UpdateCategory");

        group.MapDelete("/{id:guid}",
            async (
                [FromServices] ISender sender,
                [FromRoute] Guid id) =>
            {
                await sender.Send(new DeleteCategoryCommand(id));
                return Results.Ok();
            }).WithName("DeleteCategory");

        return group;


    }
    
    
    
}