using FluentValidation;
using FoodShop.Application.Behaviours;
using FoodShop.Application.Products;
using FoodShop.Application.Products.Commands.CreateProduct;
using FoodShop.Application.Services;
using FoodShop.Application.Services.Abstract;
using Minio;

namespace FoodShop.Api.Configuration;

public static class ApplicationServices
{
    public static IServiceCollection InstallApplicationServices(this IServiceCollection services, ConfigurationManager config)
    {

        services.AddMediatR(c =>
            {

                c.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly);
                c.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            }
                );
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