using FoodShop.Application.Abstractions.CQSegregationInterfaces;

namespace FoodShop.Application.ProductEntries.Commands.DeleteProductEntry;

public record DeleteProductEntryCommand(Guid Id) : ICommand;