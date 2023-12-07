using FoodShop.Application.Abstractions.CQSegregationInterfaces;

namespace FoodShop.Application.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand
(
    Guid Id,
    string Name,
    string Description,
    Guid CategoryId,
    string Image
) : ICommand<ProductDto>;