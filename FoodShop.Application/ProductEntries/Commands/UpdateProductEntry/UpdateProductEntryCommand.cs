using FoodShop.Application.Abstractions.CQSegregationInterfaces;
using FoodShop.Domain.Entities;

namespace FoodShop.Application.ProductEntries.Commands.UpdateProductEntry;

public record UpdateProductEntryCommand
    (Guid Id,
        Guid ProductId,
        string SKU,
        decimal Price,
        string Image,
        int Quantity) : ICommand<ProductEntryDto>;