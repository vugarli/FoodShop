using FoodShop.Application.Abstractions.CQSegregationInterfaces;
using MediatR;

namespace FoodShop.Application.Products.Commands.CreateProduct;

public sealed record CreateProductCommand
    (string Name,
        string Description,
        Guid CategoryId,
        string Image
        ) : ICommand<Guid>;
