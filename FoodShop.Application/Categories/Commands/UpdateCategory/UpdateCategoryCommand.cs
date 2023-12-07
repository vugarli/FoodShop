using FoodShop.Application.Abstractions.CQSegregationInterfaces;

namespace FoodShop.Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(Guid Id,string Name,Nullable<Guid> ParentId):ICommand<CategoryDto>;
