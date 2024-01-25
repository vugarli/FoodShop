using FoodShop.Application.Categories.Commands.CreateCategory;
using FoodShop.Application.Categories.Commands.UpdateCategory;
using FoodShop.Application.Categories.Queries.GetCategories;
using FoodShop.Application.Services.Abstract;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Minio;
using Minio.DataModel.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Presentation.Endpoints
{
    public static class FileUploadEndpoint
    {

        public static RouteGroupBuilder MapUpload(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/fileupload");
            group.WithTags("FileUpload");


            group.MapGet("/{type}/{filename}",async ([FromRoute]string filename,string type, [FromServices] IPresignedUploadUrlGeneratorService urlGenerator) =>
            {
                var url = await urlGenerator.GenerateUrlAsync(filename,type);
                return url;
            });

            return group;
        }



    }
}
