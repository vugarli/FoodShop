using FoodShop.Application.Abstractions.CQSegregationInterfaces;

namespace FoodShop.Application.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(Guid Id):ICommand;
