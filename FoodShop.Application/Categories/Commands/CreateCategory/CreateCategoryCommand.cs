using FoodShop.Application.Abstractions.CQSegregationInterfaces;

namespace FoodShop.Application.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(Nullable<Guid> ParentId,string Name):ICommand<CategoryDto>;