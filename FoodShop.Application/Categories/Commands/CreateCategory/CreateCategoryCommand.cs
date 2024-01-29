using FoodShop.Application.Abstractions.CQSegregationInterfaces;

namespace FoodShop.Application.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(Nullable<Guid> ParentId,string Name, Nullable<Guid> BaseDiscriminatorId,IEnumerable<Guid> Variations) :ICommand<CategoryDto>;