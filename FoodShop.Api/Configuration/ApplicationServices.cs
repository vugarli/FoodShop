using FluentValidation;
using FoodShop.Application.Behaviours;
using FoodShop.Application.Products.Commands.CreateProduct;

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
        return services;
    }
}