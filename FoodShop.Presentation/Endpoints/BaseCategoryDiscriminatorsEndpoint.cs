using FoodShop.Application.BaseCategoryDiscriminators.Queries.GetBaseCategoryDiscriminators;
using FoodShop.Application.Categories.Commands.CreateCategory;
using FoodShop.Application.Categories.Commands.UpdateCategory;
using FoodShop.Application.Categories.Queries.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Presentation.Endpoints
{
    public static class BaseCategoryDiscriminatorsEndpoint
    {
        public static RouteGroupBuilder MapBaseCategoryDiscriminators(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/basecategorydiscriminators");
            group.WithTags("BaseCategoryDiscriminators");

            group.MapGet("/", async ([FromServices] ISender sender) =>
            {
                var result = await sender.Send(new GetBaseCategoryDiscriminatorsQuery());
                return Results.Ok(result);
            }).WithName("GetBaseCategoryDiscriminators");


            return group;


        }
    }
}
