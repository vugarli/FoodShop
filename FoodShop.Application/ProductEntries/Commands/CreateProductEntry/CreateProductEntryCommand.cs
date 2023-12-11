using FoodShop.Application.Abstractions.CQSegregationInterfaces;

namespace FoodShop.Application.ProductEntries.Commands.CreateProductEntry;

public record 
    CreateProductEntryCommand(
        Guid ProductId,
        string SKU,
        decimal Price,
        string Image,
        int Quantity) : ICommand<ProductEntryDto>;