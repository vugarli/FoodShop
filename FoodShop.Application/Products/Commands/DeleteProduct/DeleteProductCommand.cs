using FoodShop.Application.Abstractions.CQSegregationInterfaces;

namespace FoodShop.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(Guid Id):ICommand;