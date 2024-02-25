using FoodShop.Application.Products.Commands.CreateProduct;
using FoodShop.Application.Products;
using FoodShop.Application.Services.Abstract;
using FoodShop.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShop.Application.Behaviours;
using FluentValidation;
using Microsoft.Extensions.Configuration;

namespace FoodShop.Application
{
    public static class DependencyExtensions
    {
        public static IServiceCollection InstallApplicationServices(this IServiceCollection services)
        {

            services.AddMediatR(c =>
            {

                c.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly);
                c.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            });

            services.AddValidatorsFromAssembly(typeof(CreateProductCommand).Assembly);

            services.AddSingleton<IPresignedUploadUrlGeneratorService, PresignedUploadUrlGeneratorService>();

            services.AddSingleton<IMinioClient>(c =>
            {
                var config = c.GetRequiredService<IConfiguration>();
                var endpoint = config.GetSection("MINIO").GetValue<string>("Endpoint");
                var accessKey = config.GetSection("MINIO").GetValue<string>("AccessKey");
                var secretKey = config.GetSection("MINIO").GetValue<string>("SecretKey");

                var minio = new MinioClient()
                    .WithEndpoint(endpoint)
                    .WithCredentials(accessKey, secretKey)
                    .WithSSL()
                    .Build();

                return minio;
            });

            services.AddAutoMapper(typeof(ProductDto).Assembly);

            return services;
        }


    }
}
